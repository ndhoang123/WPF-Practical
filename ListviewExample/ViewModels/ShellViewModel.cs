using Caliburn.Micro;
using ListviewExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListviewExample.ViewModels
{
	public class ShellViewModel : Screen
	{
		private string _firstName = "Sergio";

		private string _lastName;

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
				NotifyOfPropertyChange(() => FullName);
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
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public string FullName
		{
			get { return $"{FirstName} {LastName}"; }
		}

		private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

		public BindableCollection<PersonModel> People
		{
			get { return _people; }
			set { _people = value; }
		}

	}
}
