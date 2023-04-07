using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class TaskAssignments
    {
        [Key]
        public int TaskAssignmentId { get; set; }
        public int MemberGroupID { get; set; }
        [ForeignKey("MemberGroupID")]
        public virtual MembersGroups? MembersGroups{ get; set; }
        public int TaskID { get; set; }
        [ForeignKey("TaskID")]
        public virtual Tasks? Tasks { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
        [Range(0,100)]
        public int Progress { get; set; }
        public bool Status { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
    }
}
