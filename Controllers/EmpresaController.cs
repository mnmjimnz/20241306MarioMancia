using _20241306PruebaTecnicaAFP.Core.DTOs;
using _20241306PruebaTecnicaAFP.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _20241306PruebaTecnicaAFP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresa _empresa;
        private readonly IDepartamentos _departamento;
        public EmpresaController(IEmpresa empresa, IDepartamentos departamento)
        {
            _empresa = empresa;
            _departamento = departamento;
        }
        [HttpGet]
        public async Task<List<EmpresaDTO>> GetAll()
        {
            try
            {
                var x = await _empresa.ListAll();
                return x;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("ObtenerEmpresaPorId/Id")]
        public async Task<IActionResult> GetByID(int Id)
        {
            try
            {
                var x = await _empresa.GetById(Id);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Insert(EmpresaDTO empresa)
        {
            try
            {
                var x = await _empresa.Insert(empresa);
                if (x > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Ocurrio un error");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(EmpresaDTO empresa)
        {
            try
            {
                var x = await _empresa.Update(empresa);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
