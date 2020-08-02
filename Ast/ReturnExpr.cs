namespace Stannum.Ast
{
    public class ReturnExpr : Expr
    {
        public ReturnExpr(Expr value = null)
        {
            Value = value;
        }
        
        public Expr Value { get; }
    }
}