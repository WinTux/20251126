using Cliente.ConexionDatos;
using System.Diagnostics;

namespace Cliente
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestConexionDatos restConexionDatos;

        public MainPage(IRestConexionDatos restConexionDatos)
        {
            InitializeComponent();
            this.restConexionDatos = restConexionDatos;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var platos = await restConexionDatos.ObtenerPlatos();

            coleccionPlatosView.ItemsSource = platos;
        }

        // Evento Add
        private async void OnAddPlatoClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("[EVENTO] Agregar plato");
        }
        // Evento clic sobre un plato
        private async void OnPlatoSelected(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("[EVENTO] Plato seleccionado");
        }
    }
}