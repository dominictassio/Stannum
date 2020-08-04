namespace Stannum.Ast
{
    public class ContinueExpr : Expr
    {
        public ContinueExpr(string label = null)
        {
            Label = label;
        }
        
        public string Label { get; }
    }
}