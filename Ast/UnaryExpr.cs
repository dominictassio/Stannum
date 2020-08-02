namespace Stannum.Ast
{
    public class UnaryExpr : Expr
    {
        public UnaryExpr(string op, Expr right)
        {
            Op = op;
            Right = right;
        }
        
        public string Op { get; }
        
        public Expr Right { get; }
    }
}