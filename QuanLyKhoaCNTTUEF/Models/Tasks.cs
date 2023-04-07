using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? TaskID { get; set; }
        public int? EventID { get; set; }
        [ForeignKey("EventID")]
        public virtual Event? Event { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? TaskName { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
        public int? GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual Group? Group { get; set; }
    }
}
