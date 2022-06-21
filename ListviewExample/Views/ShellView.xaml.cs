using ListviewExample.Models;
using LiteDB;
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

namespace ListviewExample.Views
{
	/// <summary>
	/// Interaction logic for ShellView.xaml
	/// </summary>
	public partial class ShellView : Window
	{
		private string connectionString = @"E:\Coding-draft\dotNet\WPF\ListviewExample\ListviewExample\Customer.db";
		public ShellView()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			using (var db = new LiteDatabase(connectionString))
			{
				var col = db.GetCollection<PersonModel>("Person");

				var person = new PersonModel
				{
					FirstName = "John",
					LastName = "Doe",
					Age = 13
				};

				col.Insert(person);
			}
		}

	}
}
