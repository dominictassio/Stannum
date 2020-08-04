using System.Collections.Generic;

namespace Stannum.Ast
{
    public class LambdaExpr : Expr
    {
        public LambdaExpr(List<string> parameters, BlockStmt body)
        {
            Parameters = parameters;
            Body = body;
        }

        public List<string> Parameters { get; }
        
        public BlockStmt Body { get; }
    }
}