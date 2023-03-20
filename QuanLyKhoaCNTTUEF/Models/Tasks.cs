using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }
        public int EventID { get; set; }
        [ForeignKey("EventID")]
        public virtual Event? Event { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? TenTask { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? MoTa { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public int? Status { get; set; }
    }
}
