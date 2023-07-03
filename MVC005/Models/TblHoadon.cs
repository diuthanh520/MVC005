using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC005.Models;

public partial class TblHoadon
{
    [DisplayName("Mã hóa đơn")]
    [Required]
    public int PkIHoadonId { get; set; }
   
    public DateTime TNgaylap { get; set; }
   
    public int FkIKhachhangId { get; set; }
   
    public DateTime TNgayGiaoHang { get; set; }
    
    public string STennguoinhan { get; set; } = null!;
    
    public string SDiachigiaohang { get; set; } = null!;
    
    public string SDienthoaiNguoinhan { get; set; } = null!;

    public bool BDathanhtoan { get; set; }

   
    public string SNguoilapHoadon { get; set; } = null!;
   
    public double FTileGiamgia { get; set; }

    public virtual TblKhachhang FkIKhachhang { get; set; } = null!;

    public virtual ICollection<TblChitiethoadon> TblChitiethoadons { get; set; } = new List<TblChitiethoadon>();
}
