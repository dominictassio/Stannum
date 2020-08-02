﻿using System;
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
            var stmts = new List<Stmt>();

            for (var i = 0; i < context._Stmts.Count; i += 1)
            {
                if (!(Visit(context._Stmts[i]) is Stmt stmt))
                {
                    throw new Exception("Unrecognized statement!");
                }

                stmts.Add(stmt);
            }

            return stmts;
        }

        public override AstNode VisitDefinition(StannumParser.DefinitionContext context)
        {
            var name = context.Name.GetText();

            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new DefStmt(name, value);
        }

        public override AstNode VisitDefinitionWithoutSemi(StannumParser.DefinitionWithoutSemiContext context)
        {
            var name = context.Name.GetText();

            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }

            return new DefStmt(name, value);
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
            var label = context.Label?.GetText();

            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }

            var variable = context.Var?.GetText();

            if (!(Visit(context.Body) is BlockStmt body))
            {
                throw new Exception("Unrecognized block!");
            }

            return new ForStmt(label, value, variable, body);
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
                throw new Exception("Unrecognized if statement!");
            }

            return new IfStmt(condition, consequent, alternative);
        }

        public override AstNode VisitWhileStmt(StannumParser.WhileStmtContext context)
        {
            var label = context.Label?.GetText();

            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }

            if (!(Visit(context.Body) is BlockStmt body))
            {
                throw new Exception("Unrecognized block!");
            }

            return new WhileStmt(label, value, body);
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

            return new BinaryExpr(left, context.Op.Text, right);
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

        public override AstNode VisitCall(StannumParser.CallContext context)
        {
            if (!(Visit(context.Callee) is Expr callee))
            {
                throw new Exception("Unrecognized expression!");
            }

            var args = new List<Expr>();

            for (var i = 0; i < context._Args.Count; i += 1)
            {
                if (!(Visit(context._Args[i]) is Expr arg))
                {
                    throw new Exception("Unrecognized expression!");
                }

                args.Add(arg);
            }

            return new CallExpr(callee, args);
        }

        public override AstNode VisitAccess(StannumParser.AccessContext context)
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
            var label = context.Label?.GetText();

            return new BreakExpr(label);
        }

        public override AstNode VisitContinueExpr(StannumParser.ContinueExprContext context)
        {
            var label = context.Label?.GetText();

            return new ContinueExpr(label);
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
            
            return new NumberLit(value);
        }

        public override AstNode VisitStringLit(StannumParser.StringLitContext context)
        {
            var builder = new StringBuilder();
            var raw = context.GetText();

            for (var i = 0; i < raw.Length; i += 1)
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
            
            return new StringLit(builder.ToString());
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
            
            return new ListLit(elements);
        }

        public override AstNode VisitRecord(StannumParser.RecordContext context)
        {
            var members = new Dictionary<string, Expr>();

            for (var i = 0; i < context._Elems.Count; i += 1)
            {
                if (!(Visit(context._Elems[i]) is RecordMember member))
                {
                    throw new Exception("Unrecognized record member!");
                }

                members[member.Name] = member.Value;
            }
            
            return new RecordLit(members);
        }

        public override AstNode VisitRecordMember(StannumParser.RecordMemberContext context)
        {
            var name = context.Name.GetText();

            if (!(Visit(context.Value) is Expr value))
            {
                throw new Exception("Unrecognized expression!");
            }
            
            return new RecordMember(name, value);
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