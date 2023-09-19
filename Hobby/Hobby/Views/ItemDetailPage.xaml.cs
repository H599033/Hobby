using System.ComponentModel;
using Xamarin.Forms;
using Hobby.ViewModels;

namespace Hobby.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
