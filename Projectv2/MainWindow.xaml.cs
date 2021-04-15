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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projectv2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		JewelleryDbEntities db = new JewelleryDbEntities();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var query = from i in db.ItemTbls
						select i;

			var results = query.ToList();

			//dgItems.ItemsSource = results;
		}

		//Describe what this does
		private void btn2_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btn1_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ItemsDG_CurrentCellChanged(object sender, EventArgs e)
		{

		}

		private void btnreset_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnsave_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnupdate_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btndelete_Click(object sender, RoutedEventArgs e)
		{

		}

		private void cbxcatrgy_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void cbxtypes_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void cbxcatrgy_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void btn4_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
