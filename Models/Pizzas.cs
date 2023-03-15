using System;
namespace Pizzas
{
    public class Pizzas
    {
        private int _Id;
        public int Id { get { return _Id;} set { _Id = value;}}
        private string? _Nombre;
        public string? Nombre { get { return _Nombre;} set { _Nombre = value;}}
        private bool? _LibreGluten;
        public bool? LibreGluten { get { return _LibreGluten;} set { _LibreGluten = value;}}
        private double _Importe;
        public double Importe { get { return _Importe;} set { _Importe = value;}}
        private string? _Descripcion;
        public string? Descripcion { get { return _Descripcion;} set { _Descripcion = value;}}
    }
}