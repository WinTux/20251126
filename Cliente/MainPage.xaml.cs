using Cliente.ConexionDatos;
using Cliente.Models;
using Cliente.Paginas;
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
            var param = new Dictionary<string, object>
            {
                { nameof(Plato), new Plato() }
            };
            await Shell.Current.GoToAsync(nameof(GestionPlatosPage), param);
        }
        // Evento clic sobre un plato
        private async void OnPlatoSelected(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("[EVENTO] Plato seleccionado");
            var param = new Dictionary<string, object>
            {
                { nameof(Plato), e.CurrentSelection.FirstOrDefault() as Plato }
            };
            await Shell.Current.GoToAsync(nameof(GestionPlatosPage), param);
        }
    }
}