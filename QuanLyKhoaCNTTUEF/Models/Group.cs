using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? GroupID { get; set; }

        [DisplayName("Sự Kiện")]
        public int? EventID { get; set; }
        [ForeignKey("EventID")]
        public virtual Event? Event { get; set; }

        [DisplayName("Tên Nhóm")]
        [Column(TypeName = "nvarchar(50)")]
        public string? GroupName { get; set; }

        [DisplayName("Mô tả")]
        [Column(TypeName = "nvarchar(1000)")]
        public string? Description { get; set; }

        [DisplayName("Ngày Tạo")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Ngày Cập Nhật")]
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<MembersGroups>? MembersGroups { get; set; }
        public virtual ICollection<Tasks>? Tasks { get; set; }
    }
}
