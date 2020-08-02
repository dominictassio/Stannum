using System.Collections.Generic;

namespace Stannum.Ast
{
    public class BlockStmt : Stmt
    {
        public BlockStmt(List<Stmt> stmts)
        {
            Stmts = stmts;
        }
        
        public List<Stmt> Stmts { get; }
    }
}