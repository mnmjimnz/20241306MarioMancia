namespace _20241306PruebaTecnicaAFP.Core.DTOs
{
    public class DepartamentoDTO : EmpresaDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int numero_empleados { get; set; }
        public int nivel_organizacion{ get; set; }
        public int id_empresa { get; set; }
    }
}
