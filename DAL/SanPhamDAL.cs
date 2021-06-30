using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class SanPhamDAL : ISanPhamDAL
    {

        private IDatabaseHelper _dbHelper;
        public SanPhamDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(SanPham model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_product_create",
                        "@tensp",model.tensp,
                        "@xuatxu" , model.xuatxu,
                        "@mota"  , model.mota,
                        "@dongia"     , model.dongia,
                        "@soluong", model.soluong,
                        "@anh", model.anh,
                        "@maloai", model.maloai,
                        "@mathuonghieu", model.mathuonghieu,
                        "@namsx", model.namsx,
                        "@status", model.status,
                        "@gianhap",model.gianhap,  
                        "@dungtich",model.dungtich,
                        "@phongcach",model.phongcach
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_product_delete",
                "@masp", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(SanPham model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_product_update",
                        "@masp", model.masp,
                        "@tensp", model.tensp,
                        "@xuatxu", model.xuatxu,
                        "@mota", model.mota,
                        "@dongia", model.dongia,
                        "@soluong", model.soluong,
                        "@anh", model.anh,
                        "@maloai", model.maloai,
                        "@mathuonghieu", model.mathuonghieu,
                        //"@total", model.total,
                        "@namsx", model.namsx,
                        "@status", model.status,
                        //"@nhomhuong ", model.nhomhuong,
                        "@gianhap  ", model.gianhap,
                        "@dungtich ", model.dungtich,
                        "@phongcach", model.phongcach
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPham> Search(int pageIndex, int pageSize, out long total, string tensp, decimal dongia)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tensp", tensp,
                    "@dongia", dongia
                    //,
                    //"@status", status
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SanPham GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_get_by_id",
                     "@masp", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPham> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_pro_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPham> GetDataAll(int page_index, int page_size, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_all", "@page_index", page_index, "@page_size", page_size);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPham> GetDataNew()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_new");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPham> GetDataStatus()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_get_by_status_1");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPham> SearchCategory(int pageIndex, int pageSize, out long total, string maloai)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_get_by_category",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@maloai", maloai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPham> SearchBrand(int pageIndex, int pageSize, out long total, string mathuonghieu)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_by_brand",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@mathuonghieu", mathuonghieu);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPham> SearchHome(int pageIndex, int pageSize, out long total, string keyword)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_home_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tensp", keyword);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPham> GetProductRelated(int masp, string maloai)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_product_related",
                    "@product_id", masp,
                    "@category_id", maloai

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPham> SearchName(string searchName)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_search_name",

                    "@msg", searchName

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

