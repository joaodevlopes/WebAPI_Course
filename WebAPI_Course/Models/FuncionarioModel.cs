using System.ComponentModel.DataAnnotations;
using WebAPI_Course.Enums;

namespace WebAPI_Course.Models
{
    public class FuncionarioModel
    {
        [Key] // Significa que a coluna que vai identificar unicamente um usuario vai ser o Id
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        [Required]
        public DepartamentoEnum Departamento { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        public TurnoEnum Turno  { get; set; }
        public DateTime DataDeCriaCao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
