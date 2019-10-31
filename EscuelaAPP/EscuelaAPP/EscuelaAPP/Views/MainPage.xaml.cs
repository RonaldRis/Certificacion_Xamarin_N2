using EscuelaAPP.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EscuelaAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
        /// <summary>
        /// Para quitar el onselected item al aparecer
        /// </summary>
        protected override void OnAppearing()
        {
            ((MainPageViewModel)BindingContext).notaSelected = null;
            base.OnAppearing();
        }

        /// <summary>
        /// Esto es para quitar el OnSelected despues de seleccionarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem =null;
        }
    }

    
}