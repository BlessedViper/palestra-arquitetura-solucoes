using BlackBackup.Domain.Entities;
using BlackBackup.Domain.Interfaces.Conexoes;
using BlackBackup.EFCoreSQLite;

namespace BlackBackup.Infra.Repository
{
    public class ExcluirConexao : IExcluirConexao
    {
        private DataSQLiteContext _context;
        public ExcluirConexao(DataSQLiteContext context)
        {
            _context = context;
        }
        public void Excluir(Bucket bucket)
        {
            _context.Remove(bucket);
            _context.SaveChanges();
            _context.DeatchAllEntities();
        }
    }
}
