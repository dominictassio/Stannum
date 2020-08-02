using System.Collections.Generic;

namespace Stannum.Ast
{
    public class CallExpr : Expr
    {
        public CallExpr(Expr callee, List<Expr> args)
        {
            Callee = callee;
            Args = args;
        }
        
        public Expr Callee { get; }
        
        public List<Expr> Args { get; }
    }
}