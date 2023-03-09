using QuanLyKhoaCNTTUEF.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.ViewModel
{
    public class GroupViewModel
    {
        public int? EventID { get; set; }
        public string? GroupName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? GroupID { get; set; }
        public string? Decreption { get ; set; }
    }
}
