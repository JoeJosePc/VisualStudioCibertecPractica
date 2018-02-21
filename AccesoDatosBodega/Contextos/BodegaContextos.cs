using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.AccesoDatosBodega.Modelos;
using System.Data.Entity;

namespace Repositorio.AccesoDatosBodega.Contextos
{
    /// <summary>
    /// DbContext y remover pluralizacion de tablas
    /// </summary>
    public class BodegaContextos:DbContext
    {
        public BodegaContextos() : base("BodegaDB") { }
        public DbSet<Cliente_> Cliente { get; set; }
    }
}
