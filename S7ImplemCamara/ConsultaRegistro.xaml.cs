﻿using S7ImplemCamara.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7ImplemCamara
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {

        private SQLiteAsyncConnection _conn;

        private ObservableCollection<Estudiante> _tablaEstudiante;

        public ConsultaRegistro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var Resultado = await _conn.Table<Estudiante>().ToListAsync();
            _tablaEstudiante = new ObservableCollection<Estudiante>(Resultado);
            ListaUsuarios.ItemsSource = _tablaEstudiante;
            
            base.OnAppearing();


        }

        public void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.Id.ToString();
            int ID = Convert.ToInt32(item);

            try
            {
                Navigation.PushAsync(new Elemento(ID));
            }
            catch (Exception)
            {
                throw;
            }


        }

    }
}