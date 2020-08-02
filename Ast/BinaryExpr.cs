namespace Stannum.Ast
{
    public class BinaryExpr : Expr
    {
        public BinaryExpr(Expr left, string op, Expr right)
        {
            Left = left;
            Op = op;
            Right = right;
        }
        
        public Expr Left { get; }
        
        public string Op { get; }
        
        public Expr Right { get; }
    }
}