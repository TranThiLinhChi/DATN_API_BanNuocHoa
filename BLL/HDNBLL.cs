using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL;
using Model;

namespace BLL
{
    public partial class HDNBLL : IHDNBLL
    {
        private IHDNDAL _res;
        private ISanPhamBLL _rsp;
        public HDNBLL(IHDNDAL res, ISanPhamBLL rsp)
        {
            _res = res;
            _rsp = rsp;
        }
        public HDN Create(HDN model)
        {
            var kq = _res.Create(model);
            var tg = GetDatabyID(kq.maHDN);
            foreach (var item in tg.listjson_chitiet)
            {
                _res.TangSLSP(item.masp, item.so_luong);
            }
            return kq;
        }
        public HDN GetDatabyID(string id)
        {
            var kq = _res.GetDatabyID(id);
            kq.listjson_chitiet = _res.GetChitietbyhdn(id);
            foreach (var item in kq.listjson_chitiet)
            {
                item.tensp = _rsp.GetDatabyID(item.masp).tensp;
                item.dongia = (int)_rsp.GetDatabyID(item.masp).dongia.Value;
            }
            return kq;
        }
        //public HDN GetDatabyID(string id)
        //{
        //    return _res.GetDatabyID(id);
        //}
        //public HDN GetChiTietByhdn(string id)
        //{
        //    var kq = _res.GetDatabyID(id);
        //    kq.listjson_chitiet = _res.GetChitietbyhdn(id);
        //    foreach (var item in kq.listjson_chitiet)
        //    {
        //        item.tensp = _rsp.GetDatabyID(item.masp).tensp;
        //        item.dongia = _rsp.GetDatabyID(item.masp).dongia.Value;
        //    }

        //    return kq;
        //}
        public List<CTHDN> GetChiTietByhdn(string id)
        {
            return _res.GetChitietbyhdn(id);
        }

        public List<HDN> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<HDN> Search(int pageIndex, int pageSize, out long total, string tenNV)
        {
            return _res.Search(pageIndex, pageSize, out total, tenNV);

        }
    }
}
