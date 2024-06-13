using _20241306PruebaTecnicaAFP.Core.DTOs;
using _20241306PruebaTecnicaAFP.Core.Interface;
using Dapper;
using System.Data;

namespace _20241306PruebaTecnicaAFP.Infraestructura.Repositorio
{
    public class DepartamentosRepository : IDepartamentos
    {
        private readonly IDapper _dapperService;
        public DepartamentosRepository(IDapper dapperService)
        {
            _dapperService = dapperService;
        }
        public Task<List<DepartamentoDTO>> GetByIdEmpresa(int id)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("id_empresa", id, DbType.Int32);
            var lista = Task.FromResult(_dapperService.
                    GetAllById<DepartamentoDTO>("[dbo].[sp_getall_byempresa_departamentos]", dbParam,
                    commandType: CommandType.StoredProcedure));
            return lista;
        }
        public Task<int> Insert(DepartamentoDTO departamento)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("id_empresa", departamento.id_empresa, DbType.Int32);
            dbParam.Add("nivel_organizacion", departamento.nivel_organizacion, DbType.Int32);
            dbParam.Add("nombre", departamento.nombre, DbType.String);
            dbParam.Add("numero_empleados", departamento.numero_empleados, DbType.Int32);
            var r = Task.FromResult(_dapperService.Insert<int>(
            "[dbo].[sp_insert_departamento]", dbParam, commandType: CommandType.StoredProcedure));

            return r;
        }
    }
}
