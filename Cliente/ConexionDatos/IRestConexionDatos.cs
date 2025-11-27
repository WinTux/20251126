using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.ConexionDatos
{
    public interface IRestConexionDatos
    {
        Task<List<Models.Plato>> ObtenerPlatos();
        Task AddPlato(Models.Plato plato);
        Task UpdatePlato(Models.Plato plato);
        Task DeletePlato(int id);
    }
}
