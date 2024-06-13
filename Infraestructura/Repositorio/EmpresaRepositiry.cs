using _20241306PruebaTecnicaAFP.Core.DTOs;
using _20241306PruebaTecnicaAFP.Core.Interface;
using Dapper;
using System.Data;

namespace _20241306PruebaTecnicaAFP.Infraestructura.Repositorio
{
    public class EmpresaRepositiry: IEmpresa
    {
        private readonly IDapper _dapperService;
        public EmpresaRepositiry(IDapper dapperService)
        {
            _dapperService = dapperService;
        }
        public Task<List<EmpresaDTO>> ListAll()
        {
            var lista = Task.FromResult(_dapperService.
                    GetAll<EmpresaDTO>("[dbo].[sp_getall_empresa]", null,
                    commandType: CommandType.StoredProcedure));
            return lista;
        }
        public Task<EmpresaDTO> GetById(int id)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("id_empresa", id, DbType.Int32);
            var lista = Task.FromResult(_dapperService.
                    Get<EmpresaDTO>("[dbo].[sp_getempresa_byid]", dbParam,
                    commandType: CommandType.StoredProcedure));
            return lista;
        }
        public Task<int> Insert(EmpresaDTO empresa)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("nombre", empresa.nombre_empresa, DbType.String);
            dbParam.Add("razon_social", empresa.razon_social, DbType.String);
            var r = Task.FromResult(_dapperService.Insert<int>(
            "[dbo].[sp_insert_empresa]", dbParam, commandType: CommandType.StoredProcedure));

            return r;
        }
        public Task<int> Update(EmpresaDTO empresa)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("nombre", empresa.nombre_empresa, DbType.String);
            dbParam.Add("razon_social", empresa.razon_social, DbType.String);
            dbParam.Add("id_empresa", empresa.id, DbType.Int32); 
            var r = Task.FromResult(_dapperService.Insert<int>(
            "[dbo].[sp_update_empresa]", dbParam, commandType: CommandType.StoredProcedure));
            return r;
        }
    }
}
