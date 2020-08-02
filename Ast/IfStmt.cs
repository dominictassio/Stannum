namespace Stannum.Ast
{
    public class IfStmt : Stmt
    {
        public IfStmt(Expr condition, Stmt consequent, Stmt alternative = null)
        {
            Condition = condition;
            Consequent = consequent;
            Alternative = alternative;
        }
        
        public Expr Condition { get; }
        
        public Stmt Consequent { get; }
        
        public Stmt Alternative { get; }
    }
}