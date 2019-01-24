using System;
using System.Collections.Generic;
using System.Text;

namespace Models //ÐÞ¸ÄÃû×Ö¿Õ¼ä
{
	public class COM_DICT_DETAIL
	{
		private string cLASS_CODE;
		public string CLASS_CODE
		{
			get { return cLASS_CODE; }
			set { cLASS_CODE = value; }
		}
	
		private string iTEM_CODE;
		public string ITEM_CODE
		{
			get { return iTEM_CODE; }
			set { iTEM_CODE = value; }
		}
	
		private string iTEM_NAME;
		public string ITEM_NAME
		{
			get { return iTEM_NAME; }
			set { iTEM_NAME = value; }
		}
	
		private string iTEM_ATTR;
		public string ITEM_ATTR
		{
			get { return iTEM_ATTR; }
			set { iTEM_ATTR = value; }
		}
	
		private int oRDER_NO;
		public int ORDER_NO
		{
			get { return oRDER_NO; }
			set { oRDER_NO = value; }
		}
	
		private string mEMO;
		public string MEMO
		{
			get { return mEMO; }
			set { mEMO = value; }
		}
	}
}