using Caliburn.Micro;
using ListviewExample.Instant;
using ListviewExample.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ListviewExample.ViewModels
{
	public class ShellViewModel : Screen
	{
		private string _firstName;

		private string connectionString = @"E:\Coding-draft\dotNet\WPF\ListviewExample\ListviewExample\Customer.db";

		private string _lastName;

		private int _age;

		private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

		public ShellViewModel()
		{
			LiteDB_ListAll();
		}

		public string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				_firstName = value;
				NotifyOfPropertyChange(() => FirstName);
			}
		}

		public string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				_lastName = value;
				NotifyOfPropertyChange(() => LastName);
			}
		}


		public int Age
		{
			get { return _age; }
			set { 
				_age = value;
				NotifyOfPropertyChange(() => Age);
			}
		}

		public BindableCollection<PersonModel> People
		{
			get { return _people; }
			set { _people = value; }
		}
		public void LiteDB_ListAll()
		{
			using (var db = new LiteDatabase(connectionString))
			{
				var collection = db.GetCollection<PersonModel>("Person");
				People.Clear();

				var count = collection.Count(Query.All());

				foreach(var customer in collection.FindAll())
				{
					People.Add(customer);
				}
			}
		}

		public void Insert_LiteDB()
		{
			using (var db = new LiteDatabase(connectionString))
			{
				var col = db.GetCollection<PersonModel>("Person");

				var person = new PersonModel
				{
					FirstName = FirstName,
					LastName = LastName,
					Age = Age
				};

				col.Insert(person);
			}

			LiteDB_ListAll();
		}

		public void Open_Dialog()
		{
			var dialog = new Microsoft.Win32.OpenFileDialog();
			dialog.FileName = "Document";
			dialog.DefaultExt = ".txt";
			dialog.Filter = "Text documents (.txt)|*.txt";

			bool? result = dialog.ShowDialog();

			if(result == true)
			{
				string fileName = dialog.FileName;
			}
		}
	}
}
