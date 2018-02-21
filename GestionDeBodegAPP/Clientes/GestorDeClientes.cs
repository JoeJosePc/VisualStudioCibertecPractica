using InterfacesBodegAPP.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesBodegAPP.Clientes.Peticiones;
using InterfacesBodegAPP.Clientes.Respuestas;
using Repositorio.AccesoDatosBodega.Contextos;
using Repositorio.AccesoDatosBodega.Modelos;

namespace GestionDeBodegAPP.Clientes
{
    public class GestorDeClientes : IGestorDeClientes
    {
        public ClienteRegistrado ActualizarCliente(ClienteActualizado clienteActualizado)
        {
            using (BodegaContextos bd = new BodegaContextos())
            {
                Cliente_ cliente = bd.Cliente.Find(clienteActualizado.Id);
                cliente.Id = clienteActualizado.Id;
                cliente.Nombre = clienteActualizado.Nombre;
                cliente.Apellido = clienteActualizado.Apellido;
                cliente.Direccion = clienteActualizado.Direccion;
                bd.Entry(cliente);
                bd.SaveChanges();
                return ConvertirClienteA_DTO(cliente);
            }
        }

        public bool BorrarCliente(int ClienteID)
        {
            using(BodegaContextos bd = new BodegaContextos())
            {
                Cliente_ cliente = bd.Cliente.Find(ClienteID);
                bd.Cliente.Remove(cliente);
                bd.SaveChanges();
                return true;
            }
        }

        public ClienteRegistrado CrearCliente(NuevoCliente nuevoCliente)
        {
            using(BodegaContextos bd = new BodegaContextos())
            {
                Cliente_ cliente = new Cliente_();
                cliente.Nombre = nuevoCliente.Nombre;
                cliente.Apellido = nuevoCliente.Apellido;
                cliente.Direccion = nuevoCliente.Direccion;
                bd.Cliente.Add(cliente);
                bd.SaveChanges();
                return ConvertirClienteA_DTO(cliente);
            }
        }

        public List<ClienteRegistrado> ListarTodosLosClientes()
        {
            using(BodegaContextos bd = new BodegaContextos())
            {
                List<ClienteRegistrado> clientes = new List<ClienteRegistrado>();
                bd.Cliente.ToList().ForEach(x => clientes.Add(ConvertirClienteA_DTO(x)));
                return clientes;
            }
        }

        private ClienteRegistrado ConvertirClienteA_DTO(Cliente_ cliente)
        {
            ClienteRegistrado clienteRegistrado = new ClienteRegistrado();
            clienteRegistrado.Id = cliente.Id;
            clienteRegistrado.Nombre = cliente.Nombre;
            clienteRegistrado.Apellido = cliente.Apellido;
            clienteRegistrado.Direccion = cliente.Direccion;
            return clienteRegistrado;
        }

    }
}
