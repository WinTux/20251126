using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Models
{
    public class Plato
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set {
                if(_id == value) 
                    return;
                _id = value;
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(id)));
            }
        }
        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set {
                if(_nombre == value) 
                    return;
                _nombre = value;
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(nombre)));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
