using EscuelaAPP.Models;
using EscuelaAPP.Services;
using EscuelaAPP.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace EscuelaAPP.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        #region Contructor
        public MainPageViewModel()
        {
            notaSelected = null;
            CargarDatos();
            IsBusy = false;
        }


        #endregion

        #region Propiedades y atributos
        /// <summary>
        /// La utilizo para mostrar los datos en el LISTVIEW del page
        /// </summary>
        private ObservableCollection<notasColor> _lnotas;
        public ObservableCollection<notasColor> lnotas
        {
            get { return _lnotas; }
            set
            {
                if (value == _lnotas)
                {
                    return;
                }
                _lnotas = value;
                OnPropertyChanged("lnotas");
            }
        }

        /// <summary>
        /// Esta nota es la que me ayuda a detectar el evento TAPPED o CLICKED en el Listview
        /// </summary>
        private notasColor _notaSelected;
        public notasColor notaSelected
        {
            get { return _notaSelected; }
            set
            {
                if (value == _notaSelected)
                {
                    return;
                }
                //Aqui cambio de pagina segun el icono que selecciono
                if (value != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new NewItemPage(value.nota));
                }
                _notaSelected = null;
                OnPropertyChanged("notaSelected");

            }
        }

        #endregion


        #region Comandos 
        /// <summary>
        /// Comandos
        /// </summary>
        public ICommand CargarDatosCommand { get { return new RelayCommand(CargarDatos); } }
        public ICommand AgregarCommand { get { return new RelayCommand(Nuevo); } }
        #endregion


        #region Metodos

        /// <summary>
        /// Lee los datos desde el API y luego decide el color en caso que haya aprobado o reprobado
        /// </summary>
        private async void CargarDatos()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                List<notas> result = await APIrest.getAll();
                ObservableCollection<notasColor> notasAll = new ObservableCollection<notasColor>();
                result.ForEach(n =>
                    notasAll.Add(new notasColor()
                    {
                        nota = n,
                        color = n.promedio >= 6 ? Color.LightGreen : Color.LightCoral
                    }
                            )
                            );
                lnotas = notasAll;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Manda a la PAGE para agregar un nuevo dato desde cero
        /// </summary>
        private async void Nuevo()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewItemPage());
        }
        #endregion
    }
}
