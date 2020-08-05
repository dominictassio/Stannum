using System;
using System.Collections.Generic;
using Stannum.Ast;

namespace Stannum
{
    public class Resolver
    {
        private readonly Interpreter _interpreter;
        private readonly Stack<Dictionary<string, bool>> _scopes;
        private bool _currentLambda;
        private bool _currentLoop;

        public Resolver(Interpreter interpreter)
        {
            _interpreter = interpreter;
            _scopes = new Stack<Dictionary<string, bool>>();
            _currentLambda = false;
            _currentLoop = false;
        }

        public void Resolve(List<Stmt> statements)
        {
            for (var i = 0; i < statements.Count; i += 1)
            {
                Resolve(statements[i]);
            }
        }

        private void Resolve(Stmt statement)
        {
            BeginScope();
            
            switch (statement)
            {
                case BlockStmt blockStmt:
                    Resolve(blockStmt);
                    break;
                case DefStmt defStmt:
                    Resolve(defStmt);
                    break;
                case ExprStmt exprStmt:
                    Resolve(exprStmt);
                    break;
                case ForStmt forStmt:
                    Resolve(forStmt);
                    break;
                case IfStmt ifStmt:
                    Resolve(ifStmt);
                    break;
                case WhileStmt whileStmt:
                    Resolve(whileStmt);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(statement));
            }
            
            EndScope();
        }

        private void Resolve(BlockStmt block)
        {
            BeginScope();
            Resolve(block.Stmts);
            EndScope();
        }

        private void Resolve(DefStmt definition)
        {
            Define(definition.Name);
            Resolve(definition.Value);
        }

        private void Resolve(ExprStmt expression)
        {
            Resolve(expression.Value);
        }

        private void Resolve(ForStmt @for)
        {
            var enclosingLoop = _currentLoop;
            _currentLoop = true;
            
            Resolve(@for.Value);

            if (@for.Variable != null)
            {
                BeginScope();
                Define(@for.Variable);
            }
            
            Resolve(@for.Body);

            if (@for.Variable != null)
            {
                EndScope();
            }

            _currentLoop = enclosingLoop;
        }

        private void Resolve(IfStmt @if)
        {
            Resolve(@if.Condition);
            Resolve(@if.Consequent);

            if (@if.Alternative != null)
            {
                Resolve(@if.Alternative);
            }
        }

        private void Resolve(WhileStmt @while)
        {
            var enclosingLoop = _currentLoop;
            _currentLoop = true;
            
            Resolve(@while.Condition);
            Resolve(@while.Body);

            _currentLambda = enclosingLoop;
        }

        private void Resolve(Expr expression)
        {
            switch (expression)
            {
                case BinaryExpr binaryExpr:
                    Resolve(binaryExpr);
                    break;
                case BlockExpr blockExpr:
                    Resolve(blockExpr);
                    break;
                case BreakExpr breakExpr:
                    Resolve(breakExpr);
                    break;
                case CallExpr callExpr:
                    Resolve(callExpr);
                    break;
                case ContinueExpr continueExpr:
                    Resolve(continueExpr);
                    break;
                case Identifier identifier:
                    Resolve(identifier);
                    break;
                case IfExpr ifExpr:
                    Resolve(ifExpr);
                    break;
                case LambdaExpr lambdaExpr:
                    Resolve(lambdaExpr);
                    break;
                case Literal _:
                    // do nothing
                    break;
                case ReturnExpr returnExpr:
                    Resolve(returnExpr);
                    break;
                case UnaryExpr unaryExpr:
                    Resolve(unaryExpr);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(expression));
            }
        }

        private void Resolve(BinaryExpr binary)
        {
            Resolve(binary.Left);
            Resolve(binary.Right);
        }

        private void Resolve(BlockExpr block)
        {
            Resolve(block.Stmts);
            Resolve(block.Value);
        }

        private void Resolve(BreakExpr @break)
        {
            if (!_currentLoop)
            {
                throw new Exception("Cannot break when not in a loop!");
            }
            
            // TODO: resolve label
        }

        private void Resolve(CallExpr call)
        {
            Resolve(call.Callee);

            foreach (var arg in call.Arguments)
            {
                Resolve(arg);
            }
        }

        private void Resolve(ContinueExpr @continue)
        {
            if (!_currentLambda)
            {
                throw new Exception("Cannot continue when not in a loop!");
            }
            
            // TODO: resolve label
        }

        private void Resolve(Identifier identifier)
        {
            ResolveLocal(identifier, identifier.Value);
        }

        private void Resolve(IfExpr @if)
        {
            Resolve(@if.Condition);
            Resolve(@if.Consequent);
            Resolve(@if.Alternative);
        }

        private void Resolve(LambdaExpr lambda)
        {
            var enclosingLambda = _currentLambda;
            _currentLambda = true;
            
            BeginScope();

            foreach (var parameter in lambda.Parameters)
            {
                Define(parameter);
            }
            
            Resolve(lambda.Body);
            EndScope();

            _currentLambda = enclosingLambda;
        }

        private void Resolve(ReturnExpr @return)
        {
            if (!_currentLambda)
            {
                throw new Exception("Cannot return when not in a lambda!");
            }

            if (@return.Value != null)
            {
                Resolve(@return.Value);
            }
        }

        private void Resolve(UnaryExpr unary)
        {
            Resolve(unary.Operand);
        }

        private void BeginScope()
        {
            _scopes.Push(new Dictionary<string, bool>());
        }

        private void EndScope()
        {
            _scopes.Pop();
        }

        private void Define(string name)
        {
            if (_scopes.Count == 0)
            {
                return;
            }

            _scopes.Peek()[name] = true;
        }

        private void ResolveLocal(Expr expression, string name)
        {
            var scopes = _scopes.ToArray();
            
            for (var i = scopes.Length - 1; i >= 0; i -= 1)
            {
                if (!scopes[i].ContainsKey(name)) continue;

                return;
            }
        }
    }
}