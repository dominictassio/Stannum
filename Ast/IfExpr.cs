namespace Stannum.Ast
{
    public class IfExpr : Expr
    {
        public IfExpr(Expr condition, Expr consequent, Expr alternative)
        {
            Condition = condition;
            Consequent = consequent;
            Alternative = alternative;
        }
        
        public Expr Condition { get; }
        
        public Expr Consequent { get; }
        
        public Expr Alternative { get; }
    }
}