
using _20241306PruebaTecnicaAFP.Core.DTOs;

namespace _20241306PruebaTecnicaAFP.Core.Interface
{
    public interface IEmpresa
    {
        public Task<List<EmpresaDTO>> ListAll();
        public Task<EmpresaDTO> GetById(int id);
        public Task<int> Insert(EmpresaDTO empresa);
        public Task<int> Update(EmpresaDTO empresa);
    }
}
