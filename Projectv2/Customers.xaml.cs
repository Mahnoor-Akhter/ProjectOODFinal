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
	/// Interaction logic for Customers.xaml
	/// </summary>
	public partial class Customers : Window
	{ 
		JewelleryDbEntities db = new JewelleryDbEntities();
		public Customers()
		{
			InitializeComponent();
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var query = from i in db.CustomerTbls
						select i;

			var results = query.ToList();

			CustomersDg.ItemsSource = results;
		}
		

		private void btndelete1_Click(object sender, RoutedEventArgs e)
		{
			var Items = from c in db.CustomerTbls
						where c.CustName.StartsWith("")
						select c;

			db.CustomerTbls.RemoveRange(Items);
			db.SaveChanges();
			ShowItems(CustomersDg);
		}

		private void btnupdate1_Click(object sender, RoutedEventArgs e)
		{

			var Customers = from c in db.CustomerTbls
						where c.CustName.StartsWith("")
						select c;
			
			db.SaveChanges();
			ShowItems(CustomersDg);
		}

		private void btnsave1_Click(object sender, RoutedEventArgs e)
		{
			CustomerTbl c = new CustomerTbl()
			{
				CustName = tbxCName.Text,
				CustPhone = tbxCphone.Text
				

			};
			db.CustomerTbls.Add(c);
			db.SaveChanges();
			ShowItems(CustomersDg);

		}
		private void ShowItems(DataGrid currentGrid)
		{
			var query = from c in db.CustomerTbls
					    orderby c.CustId 
						select new
						{
							c.CustId,
							c.CustName,
							c.CustPhone
						};
			currentGrid.ItemsSource = query.ToList();
		}
		private void btnreset1_Click(object sender, RoutedEventArgs e)
		{
			Reset();
		}

		private void btn5_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			
				Items Obj = new Items();
			Obj.Show();
			this.Hide();
		}

		private void btn2_Click(object sender, RoutedEventArgs e)
		{
			Billing Obj = new Billing();
			Obj.Show();
			this.Hide();
		}
		private void Reset()
		{
			tbxCName.Text = "";
			tbxCphone.Text = "";
			
		}
	}
}
