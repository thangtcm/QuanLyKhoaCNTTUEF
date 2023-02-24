using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace QuanLyKhoaCNTTUEF.Models.Files
{
    public class PdfFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FileName { get; set; }
        public DateTime DateUpload { get; set; }
        public string? FilePath { get; set; }
        public int IDKeHoach { get; set;}
        [ForeignKey("IDKeHoach")]
        public Plan? Plan { get; set; }
    }
}
