namespace Stannum.Ast
{
    public class UnaryExpr : Expr
    {
        public UnaryExpr(string op, Expr operand)
        {
            Op = op;
            Operand = operand;
        }
        
        public string Op { get; }
        
        public Expr Operand { get; }
    }
}