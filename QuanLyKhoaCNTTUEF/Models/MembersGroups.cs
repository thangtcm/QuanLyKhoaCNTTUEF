using Microsoft.AspNetCore.Identity;
using QuanLyKhoaCNTTUEF.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class MembersGroups
    {
        public string? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser? ApplicationUser { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? GroupID { get; set; }
        [ForeignKey("GroupID")]
        public Group? Group { get; set; }
    }
}
