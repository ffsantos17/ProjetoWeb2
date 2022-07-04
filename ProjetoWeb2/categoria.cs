using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjetoWeb2
{
    [Table("categoria")]
    public class categoria
    {
        [Display(Name = "Categoria ID")]
        [Column("categoria_id")]
        public int Id { get; set; }


        [Display(Name = "Nome Categoria")]
        [Column("categoria_nome")]
        public String? Categoria_Nome { get; set; }
    }
}
