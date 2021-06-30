using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IHDNDAL
    {
        HDN Create(HDN model);
        SanPham TangSLSP(int masp, int soluong);
        List<HDN> GetDataAll();
        HDN GetDatabyID(string id);
        List<HDN> Search(int pageIndex, int pageSize, out long total, string tenNV);
        List<CTHDN> GetChitietbyhdn(string id);
    }
}
