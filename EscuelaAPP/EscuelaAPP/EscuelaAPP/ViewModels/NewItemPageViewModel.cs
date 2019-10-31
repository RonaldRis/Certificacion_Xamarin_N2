using EscuelaAPP.Models;
using EscuelaAPP.Services;
using EscuelaAPP.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EscuelaAPP.ViewModels
{
    public class NewItemPageViewModel : BaseViewModel
    {

        #region Contructor
        public NewItemPageViewModel(notas nota)
        {
            notaSelected = nota;
            nota1 = nota.nota1.ToString();
            nota2 = nota.nota2.ToString();
            nota3 = nota.nota3.ToString();

            isPut = true;
            Title = "Actualizar";
        }

        public NewItemPageViewModel()
        {
            notaSelected = new notas();
            isPut = false;
            Title = "Guardar";
        }


        #endregion

        #region Propiedades y atributos
        /// <summary>
        /// eN CASO QUE ingrese por el LIstview, es FALSE cuando va a AGREGAR un bloque de notas nuevo
        /// </summary>
        private bool _isPut;
        public bool isPut
        {
            get { return _isPut; }
            set
            {
                if (value == _isPut)
                {
                    return;
                }
                _isPut = value;
                OnPropertyChanged("isPut");
            }
        }

        /// <summary>
        /// ES el objeto que contruyo y mando para hacer los POST, DELETE o PUT
        /// </summary>
        private notas _notaSelected;
        public notas notaSelected
        {
            get { return _notaSelected; }
            set
            {
                if (value == _notaSelected)
                {
                    return;
                }
                _notaSelected = value;
                OnPropertyChanged("notaSelected");
            }
        }


        /// <summary>
        /// Bindeo con la nota 1 en XAML
        /// </summary>
        private string _nota1;
        public string nota1
        {
            get { return _nota1; }
            set
            {
                if (value == _nota1)
                {
                    return;
                }
                _nota1 = value;
                OnPropertyChanged("nota1");
            }
        }

        /// <summary>
        /// Bindeo con la nota 2 en XAML
        /// </summary>
        private string _nota2;
        public string nota2
        {
            get { return _nota2; }
            set
            {
                if (value == _nota2)
                {
                    return;
                }
                _nota2 = value;
                OnPropertyChanged("nota2");
            }
        }
        /// <summary>
        /// Bindeo con la nota 3 en XAML
        /// </summary>
        private string _nota3;
        public string nota3
        {
            get { return _nota3; }
            set
            {
                if (value == _nota3)
                {
                    return;
                }
                _nota3 = value;
                OnPropertyChanged("nota3");
            }
        }


        #endregion

        #region Comandos 

        /// <summary>
        /// Comandos
        /// </summary>
        public ICommand GuardarActualizarCommand { get { return new RelayCommand(GuardarActualizar); } }
        public ICommand EliminarCommand { get { return new RelayCommand(EliminarMethod); } }
        #endregion


        #region Metodos

        /// <summary>
        /// Manda los datos al servidor para actualizar o hacer post de un nuevo dato segun corresponda
        /// </summary>
        private async void GuardarActualizar()
        {
            IsBusy = true;

            if (await validarDatos())
            {
                if (!isPut)
                {
                    await APIrest.post(notaSelected);
                }
                else
                {
                    await APIrest.put(notaSelected.idnota, notaSelected);
                }
                IsBusy = false;
                App.Current.MainPage = new NavigationPage(new MainPage());
                return;
            }
            IsBusy = false;
        }

        /// <summary>
        /// Elimina el dato selecionado en caso que entre en un objeto ya existente y que pueda ser eliminable
        /// </summary>
        private async void EliminarMethod()
        {
            if (await App.Current.MainPage.DisplayAlert("Eliminar notas", "¿Está seguro que desea eliminar las notas? No podra recuperarlas", "Eliminar", "Cancelar"))
            {
                IsBusy = true;

                await APIrest.delete(notaSelected.idnota);
                IsBusy = false;
                App.Current.MainPage = new NavigationPage(new MainPage());

            }
        }


        /// <summary>
        /// Valido las notas en caso que quieran ingresar notas no validas
        /// </summary>
        /// <returns></returns>
        private async Task<bool> validarDatos()
        {
            try
            {
                float n1 = (float)Convert.ToDouble(nota1);
                float n2 = (float)Convert.ToDouble(nota2);
                float n3 = (float)Convert.ToDouble(nota3);

                if (n1 >= 0 && n2 >= 0 && n3 >= 0 && n1 <= 10 && n2 <= 10 && n3 <= 10)
                {
                    notaSelected.nota1 = n1;
                    notaSelected.nota2 = n2;
                    notaSelected.nota3 = n3;
                    return true;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Validaciones", "Las notas deben de estar entre 0 y 10","Ok");
                }
            }
            catch (System.Exception) { }
            return false;
        }

       
        #endregion
    }
}
