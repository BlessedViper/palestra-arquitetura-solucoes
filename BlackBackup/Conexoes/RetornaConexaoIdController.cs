﻿using BlackBackup.Domain.Entities;
using BlackBackup.Domain.Interfaces.Conexoes;
using BlackBackup.Domain.Interfaces.Controller.Conexoes;
using BlackBackup.EFCoreSQLite;
using BlackBackup.Infra.Repositorio;

namespace BlackBackup.Conexoes
{
    public class RetornaConexaoIdController : IRetornaConexaoIdController
    {
        private IRetornaConexaoId RetornaConexaoIdInfra { get; set; }

        private DataSQLiteContext _context = new();
        public Bucket RetornaConexaoId(int id)
        {
            RetornaConexaoIdInfra = new RetornaConexaoId(_context);
            return RetornaConexaoIdInfra.RetornaBucket(id);
        }
    }
}
