using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor
{
	public class IOUnit : Object
	{
		private int address = 0;
		private string strName = "";
		private int ioType = 0;
		private UInt16 iIOValue = 0;
		private string strMemo = "";

		public IOUnit()
		{
		}

		public IOUnit(int ioType, int address, string strName, string strMemo)
		{
			this.ioType = ioType;
			Address = address;
			Name = strName;
			Memo = strMemo;
		}

		public int Address
		{
			get
			{
				return address;
			}
			set
			{
				address = value;
			}
		}

		public string Name
		{
			get
			{
				return strName;
			}
			set
			{
				strName = value;
			}
		}

		public int IOType
		{
			get
			{
				return ioType;
			}
			set
			{
				ioType = value;
			}
		}

		public UInt16 IOValue
		{
			get
			{
				return iIOValue;
			}
			set
			{
				iIOValue = value;
			}
		}

		public string Memo
		{
			get
			{
				return strMemo;
			}
			set
			{
				strMemo = value;
			}
		}
	}
}
