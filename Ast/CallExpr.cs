using System.Collections.Generic;

namespace Stannum.Ast
{
    public class CallExpr : Expr
    {
        public CallExpr(Expr callee, List<Expr> arguments)
        {
            Callee = callee;
            Arguments = arguments;
        }
        
        public Expr Callee { get; }
        
        public List<Expr> Arguments { get; }
    }
}