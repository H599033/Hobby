using Hobby.Views;
using Xamarin.Forms;

namespace Hobby
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FinnHoobySide());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

