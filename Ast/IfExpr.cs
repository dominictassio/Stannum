namespace Stannum.Ast
{
    public class IfExpr : Expr
    {
        public IfExpr(Expr condition, BlockExpr consequent, Expr alternative)
        {
            Condition = condition;
            Consequent = consequent;
            Alternative = alternative;
        }
        
        public Expr Condition { get; }
        
        public BlockExpr Consequent { get; }
        
        public Expr Alternative { get; }
    }
}