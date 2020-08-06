using System;
using System.Collections.Generic;
using System.Text;
using Stannum.Ast;
using Stannum.Grammar;

namespace Stannum
{
    public class AstConverter : StannumBaseVisitor<AstNode>
    {
        public List<Stmt> Convert(StannumParser.ProgramContext context)
        {
            var definitions = new List<Stmt>();

            for (var i = 0; i < context._Defs.Count; i += 1)
            {
                if (!(Visit(context._Defs[i]) is DefStmt definition))
                {
                    throw new Exception("Unrecognized definition!");
                }

                definitions.Add(definition);
            }

            return definitions;
        }

        public List<Stmt> Convert(StannumParser.ReplContext context)
        {
            var statements = new List<Stmt>();

            for (var i = 0; i < context._Stmts.Count; i += 1)
            {
                if (!(Visit(context._Stmts[i]) is Stmt statement))
                {
                    throw new Exception("Unrecognized statement!");
                }

                statements.Add(statement);
            }

            if (context.Value != null)
            {
                if (!(Visit(context.Value) is Expr expression))
                {
                    throw new Exception("Unrecognized expression!");
                }

                statements.Add(new ExprStmt(expression));
            }

            return statements;
        }

        public override AstNode VisitDefinition(StannumParser.DefinitionContext context)
        {
            if (!(Visit(context.Name) is Identifier name))
            {
                throw new Exception("Unrecognized identifier!");
            }

            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new DefStmt(name.Value, value);
        }

        public override AstNode VisitDefinitionWithoutSemi(StannumParser.DefinitionWithoutSemiContext context)
        {
            if (!(Visit(context.Name) is Identifier name))
            {
                throw new Exception("Unrecognized identifier!");
            }

            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new DefStmt(name.Value, value);
        }

        public override AstNode VisitExprStmt(StannumParser.ExprStmtContext context)
        {
            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new ExprStmt(value);
        }

        public override AstNode VisitForStmt(StannumParser.ForStmtContext context)
        {
            if (!(Visit(context.Label) is Identifier label))
            {
                throw new Exception("Unrecognized identifier!");
            }

            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }

            var variable = context.Var?.GetText();

            if (!(Visit(context.Body) is BlockStmt body))
            {
                throw new Exception("Unrecognized block!");
            }

            return new ForStmt(label.Value, value, variable, body);
        }

        public override AstNode VisitIfStmt(StannumParser.IfStmtContext context)
        {
            if (!(Visit(context.Cond) is Expr condition))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Cons) is BlockStmt consequent))
            {
                throw new Exception("Unrecognized block statement!");
            }

            return new IfStmt(condition, consequent);
        }

        public override AstNode VisitIfElseStmt(StannumParser.IfElseStmtContext context)
        {
            if (!(Visit(context.Cond) is Expr condition))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Cons) is BlockStmt consequent))
            {
                throw new Exception("Unrecognized block statement!");
            }

            if (!(Visit(context.Alt) is BlockStmt alternative))
            {
                throw new Exception("Unrecognized block statement!");
            }

            return new IfStmt(condition, consequent, alternative);
        }

        public override AstNode VisitIfElseIfStmt(StannumParser.IfElseIfStmtContext context)
        {
            if (!(Visit(context.Cond) is Expr condition))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Cons) is BlockStmt consequent))
            {
                throw new Exception("Unrecognized block statement!");
            }

            if (!(Visit(context.AltIf) is IfStmt alternative))
            {
                throw new Exception("Unrecognized else if statement!");
            }

            return new IfStmt(condition, consequent, alternative);
        }

        public override AstNode VisitWhileStmt(StannumParser.WhileStmtContext context)
        {
            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Body) is BlockStmt body))
            {
                throw new Exception("Unrecognized block!");
            }

            if (context.Label == null)
            {
                return new WhileStmt(null, value, body);
            }
            
            if (!(Visit(context.Label) is Identifier label))
            {
                throw new Exception("Unrecognized identifier!");
            }

            return new WhileStmt(label.Value, value, body);
        }

        public override AstNode VisitBlockStmt(StannumParser.BlockStmtContext context)
        {
            var stmts = new List<Stmt>();

            for (var i = 0; i < context._Stmts.Count; i += 1)
            {
                if (!(Visit(context._Stmts[i]) is Stmt stmt))
                {
                    throw new Exception("Unrecognized statement!");
                }

                stmts.Add(stmt);
            }

            return new BlockStmt(stmts);
        }

        public override AstNode VisitAssignment(StannumParser.AssignmentContext context)
        {
            if (!(Visit(context.Left) is Expr left))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Right) is Expr right))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new BinaryExpr(left, context.Op.Text, right);
        }

        public override AstNode VisitCoalesce(StannumParser.CoalesceContext context)
        {
            if (!(Visit(context.Left) is Expr left))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Right) is Expr right))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new BinaryExpr(left, "??", right);
        }

        public override AstNode VisitLogicalOr(StannumParser.LogicalOrContext context)
        {
            if (!(Visit(context.Left) is Expr left))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Right) is Expr right))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new BinaryExpr(left, "||", right);
        }

        public override AstNode VisitLogicalAnd(StannumParser.LogicalAndContext context)
        {
            if (!(Visit(context.Left) is Expr left))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Right) is Expr right))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new BinaryExpr(left, "&&", right);
        }

        public override AstNode VisitEquality(StannumParser.EqualityContext context)
        {
            if (!(Visit(context.Left) is Expr left))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Right) is Expr right))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new BinaryExpr(left, context.Op.Text, right);
        }

        public override AstNode VisitRelational(StannumParser.RelationalContext context)
        {
            if (!(Visit(context.Left) is Expr left))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Right) is Expr right))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new BinaryExpr(left, context.Op.Text, right);
        }

        public override AstNode VisitConcatenative(StannumParser.ConcatenativeContext context)
        {
            if (!(Visit(context.Left) is Expr left))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Right) is Expr right))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new BinaryExpr(left, "++", right);
        }

        public override AstNode VisitAdditive(StannumParser.AdditiveContext context)
        {
            if (!(Visit(context.Left) is Expr left))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Right) is Expr right))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new BinaryExpr(left, context.Op.Text, right);
        }

        public override AstNode VisitMultiplicative(StannumParser.MultiplicativeContext context)
        {
            if (!(Visit(context.Left) is Expr left))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Right) is Expr right))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new BinaryExpr(left, context.Op.Text, right);
        }

        public override AstNode VisitPrefix(StannumParser.PrefixContext context)
        {
            if (!(Visit(context.Operand) is Expr operand))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new UnaryExpr(context.Op.Text, operand);
        }

        public override AstNode VisitAccess(StannumParser.AccessContext context)
        {
            if (!(Visit(context.Subject) is Expr subject))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Field) is Identifier field))
            {
                throw new Exception("Unrecognized identifier!");
            }
            
            return new BinaryExpr(subject, context.Op.Text, field);
        }

        public override AstNode VisitCall(StannumParser.CallContext context)
        {
            if (!(Visit(context.Callee) is Expr callee))
            {
                throw new Exception("Unrecognized expression!");
            }

            var arguments = new List<Expr>();

            for (var i = 0; i < context._Args.Count; i += 1)
            {
                if (!(Visit(context._Args[i]) is Expr argument))
                {
                    throw new Exception("Unrecognized expression!");
                }

                arguments.Add(argument);
            }

            return new CallExpr(callee, arguments);
        }

        public override AstNode VisitMethodCall(StannumParser.MethodCallContext context)
        {
            var arguments = new List<Expr>();
            
            if (!(Visit(context.Subject) is Expr subject))
            {
                throw new Exception("Unrecognized expression!");
            }
            
            arguments.Add(subject);
            
            if (!(Visit(context.Field) is Identifier field))
            {
                throw new Exception("Unrecognized identifier!");
            }
            
            var callee = new BinaryExpr(subject, ".", field);
            
            for (var i = 0; i < context._Args.Count; i += 1)
            {
                if (!(Visit(context._Args[i]) is Expr argument))
                {
                    throw new Exception("Unrecognized expression!");
                }

                arguments.Add(argument);
            }
            
            return new CallExpr(callee, arguments);
        }

        public override AstNode VisitBlockExpr(StannumParser.BlockExprContext context)
        {
            var stmts = new List<Stmt>();

            for (var i = 0; i < context._Stmts.Count; i += 1)
            {
                if (!(Visit(context._Stmts[i]) is Stmt stmt))
                {
                    throw new Exception("Unrecognized statement!");
                }

                stmts.Add(stmt);
            }

            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new BlockExpr(stmts, value);
        }

        public override AstNode VisitBreakExpr(StannumParser.BreakExprContext context)
        {
            if (context.Label == null)
            {
                return new BreakExpr();
            }

            if (!(Visit(context.Label) is Identifier label))
            {
                throw new Exception("Unrecognized identifier!");
            }

            return new BreakExpr(label.Value);
        }

        public override AstNode VisitContinueExpr(StannumParser.ContinueExprContext context)
        {
            if (context.Label == null)
            {
                return new ContinueExpr();
            }

            if (!(Visit(context.Label) is Identifier label))
            {
                throw new Exception("Unrecognized identifier!");
            }

            return new ContinueExpr(label.Value);
        }

        public override AstNode VisitGrouped(StannumParser.GroupedContext context)
        {
            return Visit(context.Value);
        }

        public override AstNode VisitIdentifier(StannumParser.IdentifierContext context)
        {
            var raw = context.GetText();

            if (raw.Substring(0, 1) == "$")
            {
                raw = raw.Substring(1);
            }

            var first = raw.Substring(0, 1);
            var rest = raw.Substring(1).Replace("_", "").ToLower();

            return new Identifier(first + rest);
        }

        public override AstNode VisitIfElseExpr(StannumParser.IfElseExprContext context)
        {
            if (!(Visit(context.Cond) is Expr condition))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Cons) is BlockExpr consequent))
            {
                throw new Exception("Unrecognized block expression!");
            }

            if (!(Visit(context.Alt) is BlockExpr alternative))
            {
                throw new Exception("Unrecognized block expression!");
            }

            return new IfExpr(condition, consequent, alternative);
        }

        public override AstNode VisitIfElseIfExpr(StannumParser.IfElseIfExprContext context)
        {
            if (!(Visit(context.Cond) is Expr condition))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Cons) is BlockExpr consequent))
            {
                throw new Exception("Unrecognized block expression!");
            }

            if (!(Visit(context.AltIf) is IfExpr alternative))
            {
                throw new Exception("Unrecognized if expression!");
            }

            return new IfExpr(condition, consequent, alternative);
        }

        public override AstNode VisitLambdaWithBlock(StannumParser.LambdaWithBlockContext context)
        {
            var @params = new List<string>();

            for (var i = 0; i < context._Params.Count; i += 1)
            {
                @params.Add(context._Params[i].GetText());
            }

            if (!(Visit(context.Body) is BlockStmt body))
            {
                throw new Exception("Unrecognized block statement!");
            }

            return new LambdaExpr(@params, body);
        }

        public override AstNode VisitLambdaWithExpr(StannumParser.LambdaWithExprContext context)
        {
            var @params = new List<string>();

            for (var i = 0; i < context._Params.Count; i += 1)
            {
                @params.Add(context._Params[i].GetText());
            }

            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized block statement!");
            }

            var body = new BlockStmt(new List<Stmt> {new ExprStmt(new ReturnExpr(value))});

            return new LambdaExpr(@params, body);
        }

        public override AstNode VisitNumberLit(StannumParser.NumberLitContext context)
        {
            if (!double.TryParse(context.GetText().Replace("_", ""), out var value))
            {
                throw new Exception("Unrecognized number!");
            }

            return new Literal(value);
        }

        public override AstNode VisitStringLit(StannumParser.StringLitContext context)
        {
            var builder = new StringBuilder();
            var raw = context.GetText();

            for (var i = 1; i < raw.Length - 1; i += 1)
            {
                if (raw[i] == '\\')
                {
                    i += 1;

                    builder.Append(raw[i] switch
                    {
                        '\'' => '\'',
                        '"' => '"',
                        '\\' => '\\',
                        '0' => '\0',
                        'a' => '\a',
                        'b' => '\b',
                        'f' => '\f',
                        'n' => '\n',
                        'r' => '\r',
                        't' => '\t',
                        'v' => '\v',
                        _ => throw new Exception("Unrecognized string escape sequence!")
                    });
                }
                else
                {
                    builder.Append(raw[i]);
                }
            }

            return new Literal(builder.ToString());
        }

        public override AstNode VisitList(StannumParser.ListContext context)
        {
            var elements = new List<Expr>();

            for (var i = 0; i < context._Elems.Count; i += 1)
            {
                if (!(Visit(context._Elems[i]) is Expr element))
                {
                    throw new Exception("Unrecognized expression!");
                }

                elements.Add(element);
            }

            return new Literal(elements);
        }

        public override AstNode VisitRecord(StannumParser.RecordContext context)
        {
            var members = new Dictionary<string, Expr>();

            for (var i = 0; i < context._Fields.Count; i += 1)
            {
                if (!(Visit(context._Fields[i]) is RecordField member))
                {
                    throw new Exception("Unrecognized record member!");
                }

                members[member.Name] = member.Value;
            }

            return new Literal(members);
        }

        public override AstNode VisitRecordField(StannumParser.RecordFieldContext context)
        {
            if (!(Visit(context.Name) is Identifier name))
            {
                throw new Exception("Unrecognized identifier!");
            }

            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }
            
            return new RecordField(name.Value, value);
        }

        public override AstNode VisitReturnExpr(StannumParser.ReturnExprContext context)
        {
            if (context.Value == null)
            {
                return new ReturnExpr();
            }

            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new ReturnExpr(value);
        }
    }
}