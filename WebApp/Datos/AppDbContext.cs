using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Datos
{
    public class AppDbContext : DbContext

    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {


        }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
