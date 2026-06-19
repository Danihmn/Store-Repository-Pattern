using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Infrastructure.Data.StoreContext;

public class StoreContext (DbContextOptions<StoreContext> options) : DbContext(options)
{
    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Endereco> Enderecos { get; set; }
    public virtual DbSet<Loja> Lojas { get; set; }
    public virtual DbSet<Pedido> Pedidos { get; set; }
    public virtual DbSet<Produto> Produtos { get; set; }
    public virtual DbSet<ProdutoPedido> ProdutosPedidos { get; set; }

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConnection");
    }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
}