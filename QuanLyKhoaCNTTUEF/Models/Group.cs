using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? GroupID { get; set; }

        public int? EventID { get; set; }
        [ForeignKey("EventID")]
        public Event? Event { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? TenNhom { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string? MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }

        public List<MembersGroups>? MembersGroups { get; set; }
    }
}
