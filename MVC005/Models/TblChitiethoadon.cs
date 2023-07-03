using System;
using System.Collections.Generic;

namespace MVC005.Models;

public partial class TblChitiethoadon
{
    public int FkIHoadonId { get; set; }

    public int FkIHanghoaId { get; set; }

    public int ISoluong { get; set; }

    public double FGiaban { get; set; }

    public virtual TblHanghoa FkIHanghoa { get; set; } = null!;

    public virtual TblHoadon FkIHoadon { get; set; } = null!;
}
