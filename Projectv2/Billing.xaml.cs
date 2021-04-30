using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projectv2
{
	/// <summary>
	/// Interaction logic for Billing.xaml
	/// </summary>
	public partial class Billing : Window
	{
		JewelleryDbEntities1 db = new JewelleryDbEntities1();
		Basket currentBasket;
	

		public int GetTotalInBasket { get; private set; }
		

		public Billing()
		{
			InitializeComponent();
			diaplaypro();
			displaycust();

		}
		//Show the save details of products
		private void diaplaypro()
		{
			var query = from i in db.ItemTbls
						select i;

			var results = query.ToList();

			ItemsDG.ItemsSource = results;//Product list
		}
		//Show the save details of customer
		private void displaycust()
		{
			var query = from i in db.CustomerTbls
						select i;

			var results = query.ToList();

			CustomersDg.ItemsSource = results;//Custommer details
		}
		//add to bill btn
		private void btnaddbil_Click(object sender, RoutedEventArgs e)
		{
			//get details
			CustomerTbl selectedCustomer = CustomersDg.SelectedItem as CustomerTbl;
			ItemTbl selectedItem = ItemsDG.SelectedItem as ItemTbl;
			


			if (selectedCustomer != null && selectedItem != null)
			{
				if (currentBasket == null)
				{
					currentBasket = new Basket();
					currentBasket.Customer = selectedCustomer;
				}
				//add to basket
				currentBasket.ItemsToPurchase.Add(selectedItem);

				//update text with total


				tbxtotal.Text =  string.Format("{0:C}", 
					currentBasket.GetTotalInBasket());

				//update display
				BillDG.ItemsSource = null;
				BillDG.ItemsSource = currentBasket.ItemsToPurchase;

				
			}

			//add to basket
            //update display
			//update db
			//int Grdtotal = 0;
			//BillTbl b = new BillTbl()//billtbl
			//{
            //	CustId=int.Parse(tbxCID.Text),
			//	CustName= tbxCName1.Text,
			//	Amount=int.Parse(tbxprice.Text),
			//   };

			//db.BillTbls.Add(b);

			//Grdtotal = Grdtotal + b.Amount;
			//tbxtotal.Text = "£" + Grdtotal;

			//db.SaveChanges();
			//ShowItems(BillDG);
		}
		//showItems
		private void ShowItems(DataGrid currentGrid)
		{
			var query = from b in db.BillTbls
						orderby b.CustId
						select new
						{

							b.CustId,
							b.CustName,
							b.Amount
						};
			currentGrid.ItemsSource = query.ToList();
		}

		//reset btn
		private void btnreset2_Click(object sender, RoutedEventArgs e)
		{
			reset();

		}
		private void reset()
		{
			tbxCID.Text = "";
			tbxCName1.Text = "";
			tbxBName.Text = "";
			tbxprice.Text = "";
			tbxtotal.Text = "";
		}


		//Prodcuct page

		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			Items Obj = new Items();
			Obj.Show();
			this.Hide();
		}
		//Customer page
		private void btn2_Click(object sender, RoutedEventArgs e)
		{
			CustomersDetail Obj = new CustomersDetail();
			Obj.Show();
			this.Hide();
		}

		private void ItemsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//get reference to object selected
			ItemTbl selectedItem = ItemsDG.SelectedItem as ItemTbl;

			//check not null
			if (selectedItem != null)
			{
				//display
				tbxBName.Text = selectedItem.ItName;
				tbxprice.Text = selectedItem.ItPrice.ToString();
				tbxqty.Text = selectedItem.ItQty.ToString();

			}

		}

		private void CustomersDg_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CustomerTbl seletedCust = CustomersDg.SelectedItem as CustomerTbl;

			currentBasket = new Basket();

			//check not noll
			if (seletedCust != null)
			{
				tbxCID.Text = seletedCust.CustId.ToString();
				tbxCName1.Text = seletedCust.CustName;

			}




		}

		private void btndelt_Click(object sender, RoutedEventArgs e)
		{
			var Items = from b in db.BillTbls
						where b.CustName.StartsWith("")
						select b;

			db.BillTbls.RemoveRange(Items);//delete the display details from bill box
			db.SaveChanges();
			ShowItems(BillDG);
		}
	}
}
