namespace Stannum.Ast
{
    public class BreakExpr : Expr
    {
        public BreakExpr(string label = null)
        {
            Label = label;
        }
        
        public string Label { get; }
    }
}