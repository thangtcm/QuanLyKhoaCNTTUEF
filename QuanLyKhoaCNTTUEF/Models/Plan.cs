﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDKeHoach { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? TenKeHoach { get; set; }

        public DateTime NgayTrinh { get; set; }

        public DateTime NgayDuyet { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? NguoiTrinh { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? NguoiDuyet { get; set; }

        public List<Event>? Events { get; set; }
    }
}
