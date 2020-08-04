namespace Stannum.Ast
{
    public class IfStmt : Stmt
    {
        public IfStmt(Expr condition, BlockStmt consequent, Stmt alternative = null)
        {
            Condition = condition;
            Consequent = consequent;
            Alternative = alternative;
        }
        
        public Expr Condition { get; }
        
        public BlockStmt Consequent { get; }
        
        public Stmt Alternative { get; }
    }
}