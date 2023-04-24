using Microsoft.AspNetCore.Identity;
using QuanLyKhoaCNTTUEF.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class MembersGroups
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberGroupID { get; set; }
        [DisplayName("Họ và tên")]
        public string? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public int? GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual Group? Group { get; set; }
        public string? RoleName { get; set; }
    }
}
