using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class LoaiSPBll : ILoaiSPBLL
    {
        private ILoaiSPDAL _res;
        public LoaiSPBll(ILoaiSPDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }

        public bool Create(LoaiSP model)
        {
            return _res.Create(model);
        }

        public bool Edit(string id, LoaiSP model)
        {
            return _res.Edit(id, model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<LoaiSP> GetData()
        {
            var allItemGroups = _res.GetData();
            var lstParent = allItemGroups.Where(ds => ds.parent_maloai == null).OrderBy(s => s.seq_num).ToList();
            foreach (var item in lstParent)
            {
                item.children = GetHiearchyList(allItemGroups, item);
            }
            return lstParent;
        }
        public List<LoaiSP> GetHiearchyList(List<LoaiSP> lstAll, LoaiSP node)
        {
            var lstChilds = lstAll.Where(ds => ds.parent_maloai == node.maloai).ToList();
            if (lstChilds.Count == 0)
                return null;
            for (int i = 0; i < lstChilds.Count; i++)
            {
                var childs = GetHiearchyList(lstAll, lstChilds[i]);
                lstChilds[i].type = (childs == null || childs.Count == 0) ? "leaf" : "";
                lstChilds[i].children = childs;
            }
            return lstChilds.OrderBy(s => s.seq_num).ToList();
        }
        public LoaiSP GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<LoaiSP> Search(int pageIndex, int pageSize, out long total, string tenloai)
        {
            return _res.Search(pageIndex, pageSize, out total, tenloai);
        }

    }
}
