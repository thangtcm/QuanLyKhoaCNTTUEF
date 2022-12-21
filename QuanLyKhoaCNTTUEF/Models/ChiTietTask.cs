using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class ChiTietTask
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public int IDTask { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? IDNhom { get; set; }

        public string? UserID { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? MoTa { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? KetQua { get; set; }
    }
}
