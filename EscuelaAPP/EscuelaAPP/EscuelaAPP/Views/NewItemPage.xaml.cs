using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EscuelaAPP.Models;
using EscuelaAPP.ViewModels;

namespace EscuelaAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        /// <summary>
        /// Hay dos constructores, es para diferenciar de donde mandan a llamar a la pogina y asi poder reutilizar lo visual
        /// </summary>
        /// <param name="nota"></param>
        public NewItemPage(notas nota)
        {
            InitializeComponent();

            BindingContext = new NewItemPageViewModel(nota);
        }

        public NewItemPage()
        {
            InitializeComponent();

            BindingContext = new NewItemPageViewModel();
        }

    }
}