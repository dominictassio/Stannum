using System.Collections.Generic;

namespace Stannum.Ast
{
    public class LambdaExpr : Expr
    {
        public LambdaExpr(List<string> @params, Stmt body)
        {
            Params = @params;
            Body = body;
        }

        public List<string> Params { get; }
        
        public Stmt Body { get; }
    }
}