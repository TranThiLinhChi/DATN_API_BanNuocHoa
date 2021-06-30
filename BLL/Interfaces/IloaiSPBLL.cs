using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
   public partial interface ILoaiSPBLL
    {
      
        LoaiSP GetDatabyID(string id);
        bool Create(LoaiSP model);
        bool Delete(string id);
        bool Edit(string id, LoaiSP model);
        public List<LoaiSP> GetData();
        public List<LoaiSP> Search(int pageIndex, int pageSize, out long total, string tenloai);
    }
}
