using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace groceriesBE
{
    public class Groceries
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Food { get; set; }

        public int Amount{ get; set; }

        public string? Notes { get; set; }
    }
}
