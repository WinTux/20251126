using Cliente.Paginas;

namespace Cliente
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GestionPlatosPage), typeof(GestionPlatosPage));
        }
    }
}
