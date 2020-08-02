using System.Collections.Generic;

namespace Stannum.Ast
{
    public class BlockExpr : Expr
    {
        public BlockExpr(List<Stmt> stmts, Expr value)
        {
            Stmts = stmts;
            Value = value;
        }
        
        public List<Stmt> Stmts { get; }
        
        public Expr Value { get; }
    }
}