using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	public class HDB
	{
		public string ma_hoa_don { get; set; }
		public string ho_ten { get; set; }
		public string dia_chi { get; set; }
		public string sdt { get; set; }
		public int order_total { get; set; }
		public int status { get; set; }
		public DateTime? created_at { get; set; }
		public List<CTHDB> listjson_chitiet { get; set; }
	}
}