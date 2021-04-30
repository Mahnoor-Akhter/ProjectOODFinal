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
using System.IO;
using Newtonsoft.Json;

namespace Projectv2
{
	/// <summary>
	/// Interaction logic for Customers.xaml
	/// </summary>
	public partial class CustomersDetail : Window
	{
		
		JewelleryDbEntities1 db = new JewelleryDbEntities1();
		public CustomersDetail()
		{
			InitializeComponent();
			//Jason Data part
			string data = JsonConvert.SerializeObject(GetRandomCustomers(), Formatting.Indented);
			using (StreamWriter sw = new StreamWriter("customersdetail.json"))
			{
				sw.Write(data);
				sw.Close();
			}
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var query = from i in db.CustomerTbls
						select i;

			var results = query.ToList();

			CustomersDg.ItemsSource = results;//Costomer grid
		}
		//Delete btn
		private void btndelete1_Click(object sender, RoutedEventArgs e)
		{
			var Items = from c in db.CustomerTbls
						where c.CustName.StartsWith("")
						select c;

			db.CustomerTbls.RemoveRange(Items);//Delete the details from coustomer list enter by user
			db.SaveChanges();
			ShowItems(CustomersDg);//show details about Customers
		}
		//Save btn
		private void btnsave1_Click(object sender, RoutedEventArgs e)
		{
			CustomerTbl c = new CustomerTbl()//Customer TBl
			{
				CustName = tbxCName.Text,// Name Enter by user
				CustPhone = tbxCphone.Text//Phone Enter by user
				

			};
			db.CustomerTbls.Add(c);
			db.SaveChanges();//Save details in cudtomer grid
			ShowItems(CustomersDg);//Show details

		}
		//Show details of coustomer 
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
		//Reset btn
		private void btnreset1_Click(object sender, RoutedEventArgs e)
		{
			Reset();
		}
		//close btn
		private void btn5_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		//Items(Product) page btn
		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			
			Items Obj = new Items();
			Obj.Show();
			this.Hide();
		}
		//click here btn
		private void btn2_Click(object sender, RoutedEventArgs e)
		{
			Billing Obj = new Billing(); //bil page
			Obj.Show();
			this.Hide();
		}
		//reset declare
		private void Reset()
		{
			tbxCName.Text = "";
			tbxCphone.Text = "";
			
		}
		//Json Formatt 
		private static List<CUstdetl> GetRandomCustomers()
		{
			Random rand = new Random();
			List<CUstdetl> customersDetails = new List<CUstdetl>();
			int i;
			for (i = 0; i < 30; i++)
			{
				string name = "";
				string customerName = JsonConvert.SerializeObject(name);
				int customerNumber = rand.Next();
				CUstdetl cst = new CUstdetl()
				{
					CustomerName = customerName,
					CustomerNumber = customerNumber
				};

				customersDetails.Add(cst);
			}
			return customersDetails;

		}
	}

	
}



