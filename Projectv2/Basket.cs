using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectv2
{
	public class Basket
	{
		public CustomerTbl Customer { get; set; }

		public List<ItemTbl> ItemsToPurchase { get; set; }
		public int ItPrice { get; set; }
		public int ItQty { get; set; }


		public Basket()
		{
			ItemsToPurchase = new List<ItemTbl>();
			GetTotalInBasket();
		}

		public int GetTotalInBasket()
		{
			//	//loop through items and total the amount
			var totalprice = 0m;
			foreach (var items in ItemsToPurchase)
			{
				totalprice += items.ItPrice;
			}
			return (int)totalprice;

		}

		//public int GetTotalInBasket()
		//{
		  // return ItPrice * ItQty;
		//}
	}
}
