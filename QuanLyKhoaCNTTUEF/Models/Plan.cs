using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models.Files;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? PlanID { get; set; }

        [DisplayName("Tên Kế Hoạch")]
        [Column(TypeName = "nvarchar(50)")]
        public string? PlanName { get; set; }

        [DisplayName("Ngày Trình")]
        public DateTime PresenDate { get; set; }

        [DisplayName("Ngày Duyệt")]
        public DateTime ApprovalDate { get; set; }

        [DisplayName("Người Trình")]
        public string? Presenter { get; set; }
        [ForeignKey("Presenter")]
        public virtual ApplicationUser? UserPresenter { get; set; }

        [DisplayName("Người Duyệt")]
        public string? Approver { get; set; }
        [ForeignKey("Approver")]
        public virtual ApplicationUser? UserApprover { get; set; }

        [DisplayName("Tài liệu")]
        public virtual ICollection<PdfFile>? PdfFiles { get; set; }

        public virtual ICollection<Event>? Events { get; set; }
    }
}
