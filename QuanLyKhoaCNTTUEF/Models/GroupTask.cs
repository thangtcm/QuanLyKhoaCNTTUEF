using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class GroupTask
    {
        public int GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual Group? Group { get; set; }
        public int TaskID { get; set; }
        [ForeignKey("TaskID")]
        public virtual Tasks? Tasks { get; set; }
    }
}
