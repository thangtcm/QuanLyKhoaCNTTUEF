﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class SuKien
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string IDSuKien { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Tên sự kiện")]
        [Required(ErrorMessage = "This field is required.")]
        public string TenSuKien { get; set; }

        [DisplayName("Ngày bắt đầu")]
        [Required(ErrorMessage = "This field is required.")]
        public DateTime NgayBD { get; set; }

        [DisplayName("Ngày kết thúc")]
        [Required(ErrorMessage = "This field is required.")]
        public DateTime NgayKT { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
        [DisplayName("Trạng thái")]
        public int trangthai { get; set; }
        public int XoaTam { get; set; }
        public string IDNguoiTao { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime NgayTao { get; set; }
        public string IDNguoiCapNhat { get; set; }
        [DisplayName("Ngày cập nhật")]
        public DateTime NgayCapNhat { get; set; }
        public string IDNguoiXoa { get; set; }
        [DisplayName("Ngày xoá")]
        public DateTime NgayXoa { get; set; }

    }
}
