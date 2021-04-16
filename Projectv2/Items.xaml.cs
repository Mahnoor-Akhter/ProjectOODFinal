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
	/// Interaction logic for Items.xaml
	/// </summary>
	public partial class Items : Window
	{
		JewelleryDbEntities db = new JewelleryDbEntities();
		public Items()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var query = from i in db.ItemTbls
						select i;

			var results = query.ToList();

			ItemsDG.ItemsSource = results;
		}

		//Describe what this does
		private void btn2_Click(object sender, RoutedEventArgs e)
		{
			Billing Obj = new Billing();
			Obj.Show();
			this.Hide();
		}

		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			Customers Obj = new Customers();
			Obj.Show();
			this.Hide();
		}

		

		private void btnreset_Click(object sender, RoutedEventArgs e)
		{
			Reset();

		}

		private void btnsave_Click(object sender, RoutedEventArgs e)
		{
			ItemTbl t = new ItemTbl()
			{
				ItName = tbxBName.Text,
				ItCat =  cbxcatrgy.Text,
				ItType = cbxtypes.Text,
				ItPrice =tbxprice.SelectionStart,
				ItQty = tbxquantity.SelectionLength

			};
			db.ItemTbls.Add(t);
			db.SaveChanges();
			ShowItems(ItemsDG);

		}
		private void ShowItems(DataGrid currentGrid)
		{
			var query = from t in db.ItemTbls
						where t.ItCat.Equals("Earings")
						|| t.ItCat.Equals("Ring")
						|| t.ItCat.Equals("Necklace")
						orderby t.ItId descending
						select new
						{
							t.ItId,
							t.ItName,
							t.ItCat,
							t.ItType,
							t.ItPrice,
							t.ItQty
						};
			currentGrid.ItemsSource = query.ToList();		
		}

		private void btnupdate_Click(object sender, RoutedEventArgs e)
		{
			var Items = from t in db.ItemTbls
						where t.ItName.StartsWith("")
						select t;
			foreach (var item in Items)
			{
				item.ItPrice = 10000;
			}
			db.SaveChanges();
			ShowItems(ItemsDG);
		}

		private void btndelete_Click(object sender, RoutedEventArgs e)
		{
			var Items = from t in db.ItemTbls
						where t.ItName.StartsWith("")
						select t;

			db.ItemTbls.RemoveRange(Items);
			db.SaveChanges();
			ShowItems(ItemsDG);

		}

		private void cbxcatrgy_Loaded(object sender, RoutedEventArgs e)
		{
			List<string> categories = new List<string>();
			categories.Add("Earings");
			categories.Add("Necklace");
			categories.Add("Ring");
			cbxcatrgy.ItemsSource = categories;
		}

		private void cbxtypes_Loaded(object sender, RoutedEventArgs e)
		{
			List<string> types = new List<string>();
			types.Add("Gold");
			types.Add("Silver");
			types.Add("Diamond");
			cbxtypes.ItemsSource = types;
		}

		private void cbxcatrgy_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string selectedcategories = cbxcatrgy.ItemsSource as string;
		}

		private void btn4_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Reset()
		{
			tbxBName.Text = "";
			cbxcatrgy.SelectedIndex = -1;
			cbxtypes.SelectedIndex = -1;
			tbxprice.Text = "";
			tbxquantity.Text = "";


		}
	}

}

