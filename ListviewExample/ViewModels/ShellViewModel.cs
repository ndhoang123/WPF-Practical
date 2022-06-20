using Caliburn.Micro;
using ListviewExample.Models;
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
		private string _firstName = "Sergio";

		private string _lastName;

		public ShellViewModel()
		{
			People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey", Age = 12 });
			People.Add(new PersonModel { FirstName = "Bill", LastName = "Jonas", Age = 15 });
			People.Add(new PersonModel { FirstName = "Sue", LastName = "Corey", Age = 21 });
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
	public class ScrollablePanel : StackPanel
	{
		protected override Size MeasureOverride(Size constraint)
		{
			Size tmpSize = base.MeasureOverride(constraint);
			tmpSize.Height = (double)(this.Children[0] as UIElement).GetValue(MinHeightProperty);
			return tmpSize;
		}

		protected override System.Windows.Size ArrangeOverride(System.Windows.Size finalSize)
		{
			Size tmpSize = new Size(0, 0);

			//Width stays the same
			tmpSize.Width = finalSize.Width;

			//Height is changed
			tmpSize.Height = finalSize.Height;

			//This works only for one child!
			this.Children[0].SetCurrentValue(HeightProperty, tmpSize.Height);
			this.Children[0].Arrange(new Rect(new Point(0, 0), tmpSize));

			return tmpSize;
		}
	}
}
