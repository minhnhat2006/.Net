using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLMamNon.Entity.Form
{
    public class PhieuChiBCHDTC
    {
        public int PhanLoaiChiId { get; set; }

        public string DienGiai { get; set; }

        public long SoTien { get; set; }

        public PhieuChiBCHDTC(int phanLoaiChiId, string dienGiai, long soTien)
        {
            this.PhanLoaiChiId = phanLoaiChiId;
            this.DienGiai = dienGiai;
            this.SoTien = soTien;
        }
    }
}
