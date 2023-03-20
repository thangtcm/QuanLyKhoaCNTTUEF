using Microsoft.AspNetCore.Identity;
using QuanLyKhoaCNTTUEF.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class MembersGroups
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberGroupID { get; set; }
        public string? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public int? GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual Group? Group { get; set; }
        public int? TaskID { get; set; }
        [ForeignKey("TaskID")]
        public virtual Tasks? Task { get; set; }
        public string? RoleName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateAssigned { get; set; }
    }
}
