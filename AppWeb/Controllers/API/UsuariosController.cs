using GestionDeBodegAPP.Clientes;
using InterfacesBodegAPP.Clientes;
using InterfacesBodegAPP.Clientes.Peticiones;
using InterfacesBodegAPP.Clientes.Respuestas;
using Repositorio.AccesoDatosBodega.Modelos;
using System.Collections.Generic;
using System.Web.Http;

namespace AppWeb.Controllers.API
{
    public class UsuariosController : ApiController
    {
        private IGestorDeClientes _gestorDeUsuario = new GestorDeClientes();

        // GET: api/Usuarios
        public List<ClienteRegistrado> Get()
        {
            return _gestorDeUsuario.ListarTodosLosClientes();
        }


        //// GET: api/Usuarios/5
        public Cliente_ Get(int id)
        {
            return _gestorDeUsuario.GetById(id);
        }

        // POST: api/Usuarios
        public ClienteRegistrado Post([FromBody] NuevoCliente nuevoCliente)
        {
            return _gestorDeUsuario.CrearCliente(nuevoCliente);
        }

        //// PUT: api/Usuarios/5
        public void Put(int id, [FromBody]ClienteActualizado clienteActualizado)
        {
            _gestorDeUsuario.ActualizarCliente(clienteActualizado);
        }

        // DELETE: api/Usuarios/5
        public void Delete(int id)
        {
            _gestorDeUsuario.BorrarCliente(id);
        }
    }
}
