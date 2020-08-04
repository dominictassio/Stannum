namespace Stannum.Ast
{
    public class WhileStmt : Stmt
    {
        public WhileStmt(string label, Expr condition, BlockStmt body)
        {
            Label = label;
            Condition = condition;
            Body = body;
        }

        public string Label { get; }

        public Expr Condition { get; }

        public BlockStmt Body { get; }
    }
}