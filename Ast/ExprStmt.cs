namespace Stannum.Ast
{
    public class ExprStmt : Stmt
    {
        public ExprStmt(Expr value)
        {
            Value = value;
        }
        
        public Expr Value { get; }
    }
}