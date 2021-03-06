using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IHDBDAL
    {
        bool Create(HDB model);
        List<HDB> GetDataAll();
        HDB GetDatabyID(string id);
        bool changeStatus(string id, string msg);
        List<HDB> GetByStatus(int status);
        List<HDB> Search(int pageIndex, int pageSize, out long total, string ho_ten);
        List<CTHDB> GetChitietbyhoadon(string id);
    }
}