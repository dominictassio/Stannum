namespace Stannum.Ast
{
    public class ContinueExpr : Expr
    {
        public ContinueExpr(string label)
        {
            Label = label;
        }
        
        public string Label { get; }
    }
}