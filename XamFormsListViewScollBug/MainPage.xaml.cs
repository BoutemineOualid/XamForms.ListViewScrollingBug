using System.ComponentModel;
using System.Linq;

using Xamarin.Forms;

namespace XamFormsListViewScollBug
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			// IN A REAL LIFE SCENARIO, WE WOULD BE EXECUTING AN ASYNC COMMAND
			// TO FETCH THE DATA AND UPDATING THE DISPLAYED TEMPLATE
			// DEPENDING ON THE EXECUTION STATE OF THE COMMAND AND ITS OUTCOME.

			// UNCOMMENT LINE BELLOW FOR THE WORKAROUND.
			// MainContentView.BindingContext = GetItems();

			var dataTemplate = this.Resources["ListContentTemplate"] as DataTemplate;

			MainContentView.Content = dataTemplate.CreateContent() as View;

			// BUG HERE
			MainContentView.BindingContext = GetItems();
		}

		private string[] GetItems() => Enumerable
			.Range(0, 50)
			.Select(index => $"Item {index}")
			.ToArray();
	}
}
