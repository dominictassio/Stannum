namespace Stannum.Ast
{
    public class ForStmt : Stmt
    {
        public ForStmt(string label, Expr value, string variable, BlockStmt body)
        {
            Label = label;
            Value = value;
            Variable = variable;
            Body = body;
        }

        public string Label { get; }
        
        public Expr Value { get; }

        public string Variable { get; }

        public BlockStmt Body { get; }
    }
}