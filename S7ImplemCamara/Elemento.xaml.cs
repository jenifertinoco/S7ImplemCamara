using Microsoft.SqlServer.Management.Smo;
using S7ImplemCamara.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7ImplemCamara
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLite.SQLiteConnection _conn;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;

        public Elemento(int id)
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            IdSeleccionado = id;
            InitializeComponent();
        }

        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = Actualizar(db, Nombre.Text, Usuario.Text, Contrasena.Text, IdSeleccionado);
                DisplayAlert("Alerta", "Se elimina  correctamente", "ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Error" + ex.Message, "ok");
            }
        }

        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Eliminar(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se elimina  correctamente", "ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Error" + ex.Message, "ok");
            }
        }
        public static IEnumerable<Estudiante> Eliminar(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id=?", id);

        }

        public static IEnumerable<Estudiante> Actualizar(SQLiteConnection db, string nombre, string usuario, string contrasena, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre =? , Usuario= ? ," +
                "Contrasena= ? where Id=?", nombre, usuario, contrasena, id);
        }

    }
}