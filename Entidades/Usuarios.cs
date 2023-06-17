namespace Entidades
{
    public class Usuarios
    {
        #region Atributos

        private string clave;
        private string nombreUsuario;

        #endregion Atributos

        #region Constructores

        public Usuarios()
        {
            this.nombreUsuario = "";
            this.clave = "";
        }

        public Usuarios(string nombreUsuario, string clave) : this()
        {
            this.nombreUsuario = nombreUsuario;
            this.clave = clave;
        }

        #endregion Constructores

        #region Propiedades

        public string Clave { get => clave; set => clave = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }

        #endregion Propiedades
    }
}