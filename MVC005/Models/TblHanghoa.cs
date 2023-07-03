using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC005.Models;

public partial class TblHanghoa
{
    [DisplayName("STT")]
    public int PkIHanghoaId { get; set; }
    [DisplayName("Tên hàng")]
    [Required]
  
    public string STenhang { get; set; } = null!;

    [DisplayName("Giá niêm yết")]
    [Required]
   
   
    public double FGianiemyet { get; set; }
    [DisplayName("Đặc điểm")]
    [Column(TypeName = "ntext")]
    public string? SDacdiem { get; set; }
    [DisplayName("Xuất xứ")]
    [Required]
   
    public string? SXuatxu { get; set; }
    [DisplayName("Ảnh minh họa")]

    //[ValidateNever]
    [FileExtensions(Extensions = ".png,.jpg")]
    [DataType(DataType.Upload)]
    [Display(Name = "Ảnh minh họa")]
    public string? SAnhminhhoa { get; set; }

    public virtual ICollection<TblChitiethoadon> TblChitiethoadons { get; set; } = new List<TblChitiethoadon>();
}
