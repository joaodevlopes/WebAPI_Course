using System.ComponentModel.DataAnnotations;
using WebAPI_Course.Enums;

namespace WebAPI_Course.Models
{
    public class FuncionarioModel
    {
        [Key] // Significa que a coluna que vai identificar unicamente um usuario vai ser o Id
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DepartamentoEnum Departamento { get; set; }
        public bool Ativo { get; set; }

        public TurnoEnum Turno  { get; set; }
        public DateTime DataDeCriaCao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
