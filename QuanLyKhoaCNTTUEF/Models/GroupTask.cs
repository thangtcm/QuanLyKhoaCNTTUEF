using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class GroupTask
    {
        [Key]
        public int GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual Group? Group { get; set; }
        [Key]
        public int TaskID { get; set; }
        [ForeignKey("TaskID")]
        public virtual Task? Task { get; set; }
    }
}
