using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IHDNBLL
    {
        HDN Create(HDN model);
        List<HDN> GetDataAll();
        HDN GetDatabyID(string id);
        List<CTHDN> GetChiTietByhdn(string id);
        List<HDN> Search(int pageIndex, int pageSize, out long total, string tenNV);

        //CTHDN GetChiTietByHoaDon(string id);
    }
}
