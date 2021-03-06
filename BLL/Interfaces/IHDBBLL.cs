using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IHDBBLL
    {
        bool Create(HDB model);
        List<HDB> GetDataAll();
        HDB GetDatabyID(string id);
        HDB GetChiTietByHoaDon(string id);
        bool changeStatus(string id, string msg);
        List<HDB> GetByStatus(int status);
        List<HDB> Search(int pageIndex, int pageSize, out long total, string ho_ten);
    }
}
