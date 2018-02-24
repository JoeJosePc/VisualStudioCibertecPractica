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
                Cliente_ cliente = bd.Cliente.Find(clienteActualizado.id);
                cliente.id = clienteActualizado.id;
                cliente.nombre = clienteActualizado.nombre;
                cliente.apellido = clienteActualizado.apellido;
                cliente.direccion = clienteActualizado.direccion;
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
                cliente.nombre = nuevoCliente.nombre;
                cliente.apellido = nuevoCliente.apellido;
                cliente.direccion = nuevoCliente.direccion;
                bd.Cliente.Add(cliente);
                bd.SaveChanges();
                return ConvertirClienteA_DTO(cliente);
            }
        }

        public Cliente_ GetById(int id)
        {
            using (BodegaContextos bd = new BodegaContextos())
            {
                return bd.Cliente.FirstOrDefault(x => x.id == id);
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
            clienteRegistrado.id = cliente.id;
            clienteRegistrado.nombre = cliente.nombre;
            clienteRegistrado.apellido = cliente.apellido;
            clienteRegistrado.direccion = cliente.direccion;
            return clienteRegistrado;
        }

    }
}
