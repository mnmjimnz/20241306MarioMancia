using _20241306PruebaTecnicaAFP.Core.DTOs;
using _20241306PruebaTecnicaAFP.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _20241306PruebaTecnicaAFP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentos _departamento;
        public DepartamentosController(IEmpresa empresa, IDepartamentos departamento)
        {
            _departamento = departamento;
        }

        [HttpGet("VerDepartamentosPorEmpresa/{Id}")]
        public async Task<IActionResult> VerDepartamentos(int Id)
        {
            try
            {
                var x = await _departamento.GetByIdEmpresa(Id);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Insert(DepartamentoDTO departamento)
        {
            try
            {
                var x = await _departamento.Insert(departamento);
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
    }
}

