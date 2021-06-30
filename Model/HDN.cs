using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class HDN
    {
        public string maHDN { get; set; }
        public string tenNV { get; set; }
        public string dia_chi { get; set; }
        public string sdt { get; set; }
        public DateTime? ngaynhap { get; set; }
        public int Tongdonvi { get; set; }
        public int Tongchiphi { get; set; }
        public List<CTHDN> listjson_chitiet { get; set; }
    }
}
