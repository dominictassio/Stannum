namespace Stannum.Ast
{
    public class WhileStmt : Stmt
    {
        public WhileStmt(string label, Expr value, Stmt body)
        {
            Label = label;
            Value = value;
            Body = body;
        }

        public string Label { get; }

        public Expr Value { get; }

        public Stmt Body { get; }
    }
}