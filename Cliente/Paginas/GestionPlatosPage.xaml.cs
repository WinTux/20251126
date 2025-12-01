using Cliente.ConexionDatos;
using Cliente.Models;
using System.Reflection.Metadata.Ecma335;

namespace Cliente.Paginas;
[QueryProperty(nameof(plato), "Plato")]
public partial class GestionPlatosPage : ContentPage
{
    private readonly IRestConexionDatos conexionDatos;
    private Plato _plato;
    private bool _esNuevo;
    public Plato plato
    {
        get => _plato; 
        set {
            _esNuevo = esNuevo(value);
            _plato = value;
            OnPropertyChanged();
        }
    }
    public GestionPlatosPage(IRestConexionDatos conexionDatos)
	{
		InitializeComponent();
		this.conexionDatos = conexionDatos;
        BindingContext = this;
    }

    bool esNuevo(Plato plato) { 
        if(plato.id == 0) 
            return true;
        return false;
    }
    async void OnCancelarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
    async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (_esNuevo)
        {
            await conexionDatos.AddPlato(plato);
        }
        else
        {
            await conexionDatos.UpdatePlato(plato);
        }
        await Shell.Current.GoToAsync("..");
    }
    async void OnEliminarClicked(object sender, EventArgs e)
    {
        await conexionDatos.DeletePlato(plato.id);
        await Shell.Current.GoToAsync("..");
    }
}