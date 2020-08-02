namespace Stannum.Ast
{
    public class BreakExpr : Expr
    {
        public BreakExpr(string label)
        {
            Label = label;
        }
        
        public string Label { get; }
    }
}