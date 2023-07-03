using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC005.Models;

public partial class TblKhachhang
{
    public int PkIKhachhangId { get; set; }
   
    public string SHoten { get; set; } = null!;
   
    public string? SDiachi { get; set; }
   
   
    public string? SDienthoai { get; set; }
    
    public bool BGioitinh { get; set; }
   
    public DateTime TNgaysinh { get; set; }
   
 
    public string? STenCoquan { get; set; }

    public virtual ICollection<TblHoadon> TblHoadons { get; set; } = new List<TblHoadon>();
}
