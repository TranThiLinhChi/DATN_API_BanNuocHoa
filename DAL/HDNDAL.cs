using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public partial class HDNDAL:IHDNDAL
    {
        private IDatabaseHelper _dbHelper;
        public HDNDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public HDN Create(HDN model)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hdn_create",
                "@maHDN", model.maHDN,
                "@tenNV", model.tenNV,
                "@dia_chi", model.dia_chi,
                "@sdt", model.sdt,
                "@ngaynhap", model.ngaynhap,
                "@listjson_chitiet", model.listjson_chitiet != null ? MessageConvert.SerializeObject(model.listjson_chitiet) : null);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<HDN>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HDN> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hdn_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HDN>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HDN> Search(int pageIndex, int pageSize, out long total, string tenNV)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hdn_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tenNV", tenNV);

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HDN>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HDN GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hdn_get_by_id",
                     "@maHDN", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HDN>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CTHDN> GetChitietbyhdn(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_chitiet_by_hdn",
                     "@maHDN", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CTHDN>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SanPham TangSLSP(int masp, int soluong)
        {

            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "tangslsp",
                    "@masp", masp,
                    "@soluong", soluong
                   );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<SanPham>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
