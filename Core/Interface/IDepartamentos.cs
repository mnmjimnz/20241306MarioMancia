using _20241306PruebaTecnicaAFP.Core.DTOs;

namespace _20241306PruebaTecnicaAFP.Core.Interface
{
    public interface IDepartamentos
    {
        public Task<List<DepartamentoDTO>> GetByIdEmpresa(int id);
        public Task<int> Insert(DepartamentoDTO departamento);
    }
}
