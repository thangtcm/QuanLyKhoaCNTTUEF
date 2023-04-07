using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class DetailTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TaskID { get; set; }
        [ForeignKey("TaskID")]
        public virtual Tasks? Task { get; set; }
        public int? GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual Group? Group { get; set; }
        public string? UserID { get; set; }
        public int? MembersGroupID { get; set; }
        [ForeignKey("MemberGroupID")]
        public virtual MembersGroups? MembersGroups { get; set; }
        public int AssignedGroupId { get; set; }
        public int AssignedMemberId { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Description { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? KetQua { get; set; }
    }
}
