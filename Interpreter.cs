using System;
using System.Collections.Generic;
using System.Linq;
using Stannum.Ast;

namespace Stannum
{
    public class Interpreter
    {
        private Environment _environment;

        public Interpreter(Environment environment = null)
        {
            _environment = environment ?? new Environment();
        }

        public void Interpret(List<Stmt> statements)
        {
            try
            {
                for (var i = 0; i < statements.Count; i += 1)
                {
                    Execute(statements[i]);
                }
            }
            catch (RuntimeException e)
            {
                Console.WriteLine("=== Runtime Error ===");
                Console.WriteLine(e.Message);
            }
        }

        public void ExecuteBlock(List<Stmt> statements, Environment environment)
        {
            var previous = _environment;

            try
            {
                _environment = new Environment(environment);
                
                for (var i = 0; i < statements.Count; i += 1)
                {
                    Execute(statements[i]);
                }
            }
            catch (RuntimeException e)
            {
                Console.WriteLine("=== Runtime Error ===");
                Console.WriteLine(e.Message);
            }
            finally
            {
                _environment = previous;
            }
        }

        private void Execute(Stmt statement)
        {
            switch (statement)
            {
                case BlockStmt blockStmt:
                    Execute(blockStmt);
                    break;
                case DefStmt defStmt:
                    Execute(defStmt);
                    break;
                case ExprStmt exprStmt:
                    Execute(exprStmt);
                    break;
                case ForStmt forStmt:
                    Execute(forStmt);
                    break;
                case IfStmt ifStmt:
                    Execute(ifStmt);
                    break;
                case WhileStmt whileStmt:
                    Execute(whileStmt);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(statement));
            }
        }

        private void Execute(BlockStmt block)
        {
            ExecuteBlock(block.Stmts, new Environment(_environment));
        }

        private void Execute(DefStmt definition)
        {
            _environment.Define(definition.Name, Evaluate(definition.Value));
        }

        private void Execute(ExprStmt expression)
        {
            Evaluate(expression.Value);
        }

        private void Execute(ForStmt @for)
        {
            throw new NotImplementedException();
        }

        private void Execute(IfStmt @if)
        {
            if (IsTruthy(Evaluate(@if.Condition)))
            {
                Execute(@if.Consequent);
            }
            else if (@if.Alternative != null)
            {
                Execute(@if.Alternative);
            }
        }

        private void Execute(WhileStmt @while)
        {
            try
            {
                while (IsTruthy(Evaluate(@while.Condition)))
                {
                    try
                    {
                        Execute(@while.Body);
                    }
                    catch (ContinueException @continue)
                    {
                        if (!(@continue.Label == @while.Label || @continue.Label == null))
                        {
                            throw;
                        }
                    }
                }
            }
            catch (BreakException @break)
            {
                if (!(@break.Label == @while.Label || @break.Label == null))
                {
                    throw;
                }
            }
        }

        private object Evaluate(Expr expression)
        {
            return expression switch
            {
                BinaryExpr binaryExpr => Evaluate(binaryExpr),
                BlockExpr blockExpr => Evaluate(blockExpr),
                BreakExpr breakExpr => Evaluate(breakExpr),
                CallExpr callExpr => Evaluate(callExpr),
                ContinueExpr continueExpr => Evaluate(continueExpr),
                Identifier identifier => Evaluate(identifier),
                IfExpr ifExpr => Evaluate(ifExpr),
                LambdaExpr lambdaExpr => Evaluate(lambdaExpr),
                Literal literal => Evaluate(literal),
                ReturnExpr returnExpr => Evaluate(returnExpr),
                UnaryExpr unaryExpr => Evaluate(unaryExpr),
                _ => throw new ArgumentOutOfRangeException(nameof(expression))
            };
        }

        private object Evaluate(BinaryExpr binary)
        {
            switch (binary.Op)
            {
                case ":=":
                case "+=":
                case "-=":
                case "*=":
                case "/=":
                case "%=":
                    return AssignmentOperation(binary.Op, binary.Left, Evaluate(binary.Right));

                case "??":
                    return Evaluate(binary.Left) ?? Evaluate(binary.Right);

                case "||":
                {
                    var left = Evaluate(binary.Left);

                    return IsTruthy(left) ? left : Evaluate(binary.Right);
                }

                case "&&":
                {
                    var left = Evaluate(binary.Left);

                    return !IsTruthy(left) ? left : Evaluate(binary.Right);
                }

                case "==":
                    return IsEqual(Evaluate(binary.Left), Evaluate(binary.Right));

                case "!=":
                    return !IsEqual(Evaluate(binary.Left), Evaluate(binary.Right));

                case "<":
                case "<=":
                case ">":
                case ">=":
                    return RelationalOperation(binary.Op, Evaluate(binary.Left), Evaluate(binary.Right));

                case "++":
                {
                    var left = Evaluate(binary.Left);
                    var right = Evaluate(binary.Right);

                    switch (left)
                    {
                        case List<object> leftList when right is List<object> rightList:
                        {
                            var list = new List<object>();

                            for (var i = 0; i < leftList.Count; i += 1)
                            {
                                list.Add(leftList[i]);
                            }

                            for (var i = 0; i < rightList.Count; i += 1)
                            {
                                list.Add(rightList[i]);
                            }

                            return list;
                        }

                        case string leftString when right is string rightString:
                            return $"{leftString}{rightString}";

                        default:
                            throw new Exception("Operands must be both lists or both strings!");
                    }
                }

                case "+":
                case "-":
                case "*":
                case "/":
                case "%":
                    return NumericalOperation(binary.Op, Evaluate(binary.Left), Evaluate(binary.Right));

                case ".":
                case "?.":
                {
                    return AccessOperation(binary.Op, Evaluate(binary.Left), binary.Right);
                }

                default:
                    throw new RuntimeException("Unrecognized binary operator!");
            }
        }

        private object Evaluate(BlockExpr block)
        {
            _environment = new Environment(_environment);

            Interpret(block.Stmts);

            var result = Evaluate(block.Value);

            _environment = _environment.Enclosing;

            return result;
        }

        private object Evaluate(BreakExpr @break)
        {
            throw new BreakException(@break.Label);
        }

        private object Evaluate(CallExpr call)
        {
            var callee = Evaluate(call.Callee);
            var arguments = call.Arguments.Select(Evaluate).ToList();

            if (!(callee is ICallable function))
            {
                throw new RuntimeException("Can only call functions!");
            }

            return function.Call(this, arguments);
        }

        private object Evaluate(ContinueExpr @continue)
        {
            throw new ContinueException(@continue.Label);
        }

        private object Evaluate(Identifier identifier)
        {
            return _environment[identifier.Value];
        }

        private object Evaluate(IfExpr @if)
        {
            return Evaluate(IsTruthy(Evaluate(@if.Condition)) ? @if.Consequent : @if.Alternative);
        }

        private object Evaluate(LambdaExpr lambda)
        {
            return new Lambda(lambda.Parameters, lambda.Body, _environment);
        }

        private object Evaluate(Literal literal)
        {
            switch (literal.Value)
            {
                case List<Expr> expressions:
                    return expressions.Select(Evaluate).ToList();

                case Dictionary<string, Expr> fields:
                {
                    var record = new Dictionary<string, object>();

                    foreach (var field in fields.Keys)
                    {
                        record[field] = Evaluate(fields[field]);
                    }

                    return record;
                }

                default:
                    return literal.Value;
            }
        }

        private object Evaluate(ReturnExpr @return)
        {
            throw new ReturnException(Evaluate(@return.Value));
        }

        private object Evaluate(UnaryExpr unary)
        {
            var operand = Evaluate(unary.Operand);

            switch (unary.Op)
            {
                case "!":
                    return !IsTruthy(operand);

                case "-":
                {
                    if (!(operand is double dr))
                    {
                        throw new Exception("Operand must be a number!");
                    }

                    return -dr;
                }

                default:
                    throw new Exception("Unrecognized unary operator!");
            }
        }

        public static string Stringify(object obj)
        {
            if (obj == null)
            {
                return "None";
            }

            if (obj is string s)
            {
                return $"\"{s}\"";
            }

            if (obj is Dictionary<string, object> record)
            {
                return $"{{ {string.Join(", ", record.Select(field => $"{field.Key} = {Stringify(field.Value)}"))} }}";
            }

            if (obj is List<object> list)
            {
                return $"[{string.Join(", ", list)}]";
            }

            return obj.ToString();
        }

        private object AssignmentOperation(string op, Expr a, object b)
        {
            switch (a)
            {
                case BinaryExpr binary:
                {
                    var left = Evaluate(binary.Left);

                    if (binary.Op == "?." && left == null)
                    {
                        return null;
                    }

                    if (!(left is Dictionary<string, object> record))
                    {
                        throw new RuntimeException("Can only access fields on records!");
                    }

                    if (!(binary.Right is Identifier identifier))
                    {
                        throw new RuntimeException("Can only use identifier as a field!");
                    }

                    if (!op.Contains(":"))
                    {
                        b = NumericalOperation(op.Substring(0, 1), record[identifier.Value], b);
                    }

                    record[identifier.Value] = b;

                    break;
                }

                case Identifier identifier:
                {
                    if (!op.Contains(":"))
                    {
                        b = NumericalOperation(op.Substring(0, 1), Evaluate(identifier), b);
                    }

                    _environment.Assign(identifier.Value, b);

                    break;
                }

                default:
                    throw new RuntimeException("Could not assign to non-access or non-identifier!");
            }

            return b;
        }

        private static bool RelationalOperation(string op, object a, object b)
        {
            if (!(a is double left) || !(b is double right))
            {
                throw new RuntimeException("Operands must both be numbers!");
            }

            return op switch
            {
                "<" => left < right,
                "<=" => left <= right,
                ">" => left > right,
                ">=" => left >= right,
                _ => throw new Exception("Unrecognized relational operator!")
            };
        }

        private static double NumericalOperation(string op, object a, object b)
        {
            if (!(a is double left) || !(b is double right))
            {
                throw new RuntimeException("Operands must both be numbers!");
            }

            return op switch
            {
                "+" => left + right,
                "-" => left - right,
                "*" => left * right,
                "/" => left / right,
                "%" => left % right,
                _ => throw new Exception("Unrecognized numerical operator!")
            };
        }

        private static object AccessOperation(string op, object left, object right)
        {
            if (op == "?." && left == null)
            {
                return null;
            }

            if (!(left is Dictionary<string, object> record))
            {
                throw new RuntimeException("Can only access fields on records!");
            }

            if (!(right is Identifier identifier))
            {
                throw new RuntimeException("Can only use identifier as a field!");
            }

            var field = identifier.Value;

            if (!record.TryGetValue(field, out var value))
            {
                throw new RuntimeException($"Field {field} doesn't exist on record!");
            }

            return value;
        }

        private static bool IsEqual(object a, object b)
        {
            return a switch
            {
                null when b == null => true,
                null => false,
                _ => a.Equals(b)
            };
        }

        private static bool IsTruthy(object o)
        {
            return o switch
            {
                null => false,
                bool b => b,
                _ => true
            };
        }
    }
}