using BlackBackup.Domain.Entities;
using BlackBackup.Domain.Interfaces.Conexoes;
using BlackBackup.Domain.Interfaces.Controller.Conexoes;
using BlackBackup.EFCoreSQLite;
using BlackBackup.Infra.Repository;

namespace BlackBackup.Conexoes
{
    public class ExcluirConexaoController : IExcluirConexaoController
    {
        private IExcluirConexao? ExcluirConexaoInfra { get; set; }
        private DataSQLiteContext _context = new();
        public void ExcluirConexao(Bucket bucket)
        {
            ExcluirConexaoInfra = new ExcluirConexao(_context);
            ExcluirConexaoInfra.Excluir(bucket);
        }
    }
}
