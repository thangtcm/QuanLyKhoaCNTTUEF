using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class ChiTietTask
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public int IDNhom { get; set; }
        [Column(TypeName = "varchar(50)")]
        public int UserID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public int IDTask { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string MoTa { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string KetQua { get; set; }
    }
}
