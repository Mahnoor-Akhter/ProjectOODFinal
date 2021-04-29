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
		JewelleryDbEntities1 db = new JewelleryDbEntities1();
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

		//Access To Bill Page Click Here
		private void btn2_Click(object sender, RoutedEventArgs e)
		{
			Billing Obj = new Billing();//bil pge
			Obj.Show();
			this.Hide();
		}
		//Access to Customer Page
		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			CustomersDetail Obj = new CustomersDetail();//Customer Page
			Obj.Show();
			this.Hide();
		}

		
		//Reset Btn
		private void btnreset_Click(object sender, RoutedEventArgs e)
		{
			Reset();

		}
		//Save btn
		private void btnsave_Click(object sender, RoutedEventArgs e)
		{
			ItemTbl t = new ItemTbl()//items tbl
			{
				ItName = tbxBName.Text,//Name enter by the user
				ItCat =  cbxcatrgy.Text,//Catagery enter by the user
				ItType = cbxtypes.Text,//Type enter by the user
				ItPrice =int.Parse( tbxprice.Text),//Price enter by the user
				ItQty = int.Parse(tbxquantity.Text)//Quntity enter by the user

			};
			db.ItemTbls.Add(t);
			db.SaveChanges();
			ShowItems(ItemsDG);//show items enter by user in Product list box

		}
		//ShowItems in Product Grid
		private void ShowItems(DataGrid currentGrid)
		{
			var query = from t in db.ItemTbls
						where t.ItCat.Equals("Earings")
						|| t.ItCat.Equals("Ring")
						|| t.ItCat.Equals("Necklace")
						|| t.ItCat.Equals("Brooch")
						|| t.ItCat.Equals("Bracelet")
						|| t.ItCat.Equals("Watch")
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

		
		//Delete btn
		private void btndelete_Click(object sender, RoutedEventArgs e)
		{
			var Items = from t in db.ItemTbls
						where t.ItName.StartsWith("")
						select t;

			db.ItemTbls.RemoveRange(Items);//delete the display details from products box
			db.SaveChanges();
			ShowItems(ItemsDG);

		}
		//Catageries/Varities list 
		private void cbxcatrgy_Loaded(object sender, RoutedEventArgs e)
		{
			List<string> categories = new List<string>();//list show in combo box of catergery 
			categories.Add("Earings");//Earings
			categories.Add("Necklace");//Necklace
			categories.Add("Brooch");//Brooch
			categories.Add("Ring");//Ring
			categories.Add("Bracelet");//Bracelet
			categories.Add("Watch");//Watch

			cbxcatrgy.ItemsSource = categories;
		}
		//Types list
		private void cbxtypes_Loaded(object sender, RoutedEventArgs e)
		{
			List<string> types = new List<string>();//list show in comboox type
			types.Add("Gold");//Gold
			types.Add("Silver");//Silver
			types.Add("Diamond");//Diamond
			cbxtypes.ItemsSource = types;
		}

		private void cbxcatrgy_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string selectedcategories = cbxcatrgy.ItemsSource as string;
		}
		//Close btn
		private void btn4_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		//Reset details
		private void Reset()
		{
			tbxBName.Text = "";
			cbxcatrgy.SelectedIndex = -1;
			cbxtypes.SelectedIndex = -1;
			tbxprice.Text = "";
			tbxquantity.Text = "";


		}

		


		
		
		

		//private void filtercatry_Loaded(object sender, RoutedEventArgs e)
		//{
		//	List<string> categories = new List<string>();//list show in combo box of catergery
		//	categories.Add("All");
		//	categories.Add("Earings");//Earings
		//	categories.Add("Necklace");//Necklace
		//	categories.Add("Brooch");//Brooch
		//	categories.Add("Ring");//Ring
		//	categories.Add("Bracelet");//Bracelet
		//	categories.Add("Watch");//Watch

		//	filtercatry.ItemsSource = categories;
		//}
	}

}

