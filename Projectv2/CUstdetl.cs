using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectv2
{
	public class CUstdetl 
	{
		public string CustomerName { get; set; }

		public int CustomerNumber { get; set; }

		public CUstdetl(string customerName,int customerNumber)
		{
			CustomerName = customerName;
			CustomerNumber = customerNumber;
		}
		public CUstdetl(string customerName):this(customerName,0) { }
		public CUstdetl() : this("Unknown") { }

		public override string ToString()
		{
			return string.Format("[{0}] {1} {2:C}",this.GetType().Name.ToUpper(),CustomerName,CustomerNumber);
		}


	}
}
