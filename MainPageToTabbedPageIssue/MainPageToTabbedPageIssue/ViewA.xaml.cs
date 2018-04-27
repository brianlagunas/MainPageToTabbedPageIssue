using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MainPageToTabbedPageIssue
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewA : ContentPage
	{
		public ViewA ()
		{
			InitializeComponent ();

            _button.Clicked += _button_Clicked;
		}

        private void _button_Clicked(object sender, EventArgs e)
        {
            //build up navigation stack
            var tabbedPage = new TabbedPage();
            tabbedPage.Navigation.PushModalAsync(new ViewB());

            //shoud have 1, this is correct
            var numberOfPages = tabbedPage.Navigation.ModalStack.Count;

            //reset main page - View should be showing, but it's a blank screen
            App.Current.MainPage = tabbedPage;

            //should have 1 page on modal stack, but now there is only 1
            numberOfPages = tabbedPage.Navigation.ModalStack.Count;
        }
    }
}