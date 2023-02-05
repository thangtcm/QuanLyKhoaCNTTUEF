using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Group
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string? GroupID { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? EventID { get; set; }
        [ForeignKey("EventID")]
        public Event? Event { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? TenNhom { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string? MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }

        public List<MembersGroups>? MembersGroups { get; set; }
    }
}
