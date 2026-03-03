
using GCook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyRecipes.Models;

namespace MyRecipes.Data;

public class AppDbContext : IdentityDbContext<Usuario> //para especificar o Usuario
//isso deixa a gente manipular o banco de dados e o usuario tambem, a lib ja sabe como
//fazer a conexao, entao a minha unica preocupação é criar os dados do banco
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //esse construtor é necessário para passar as opções de configuração do banco de dados para a classe base IdentityDbContext
    //, que é responsável por configurar o contexto do banco de dados e as entidades relacionadas à identidade do usuário.
    {
     //resumidamente, as infos daqui passa pra classe


    }

    public DbSet<Categoria> Categorias { get; set; }
    //precisamos de um DBset, que é o que precisamos pra manipular uma lista dentro do banco
    public DbSet<Ingrediente> Ingredientes { get; set;}

    public DbSet<Preparo> Preparos { get; set; }

    public DbSet<ReceitaIngrediente> ReceitaIngredientes { get; set; }

    public DbSet<Receita> Receitas { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }
    //cada Dbset permite a gente manipular uma tabela do banco de dados
    //ent cada Dbset é uma tabela

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //definindo chave primaria composta para a tabela de relacionamento entre Receita e Ingrediente
        builder.Entity<ReceitaIngrediente>()
            .HasKey(ri => new { ri.ReceitaId, ri.IngredienteId });
            //ri = ReceitaIngrediente, igual na classe, o colum ordem 1 é o receita, e o 2 é o ingrediente
            //isso garante que cada combinação de receita e ingrediente seja única na tabela

            #region DefiniçãoDeNomes
            //definindo os nomes das tabelas no banco de dados
            /*
            cada entity é correspondente aos models, que recebe uma key
            */    
            builder.Entity<Usuario>().ToTable("Usuarios"); //somente essa é necessaria ( Entity<Usuario> ), as outras são opcionais, mas é bom definir pra ficar organizado
            builder.Entity<IdentityRole>().ToTable("Perfis");
            builder.Entity<IdentityUserRole<string>>().ToTable("UsuarioPerfis");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UsuarioRegras");
            builder.Entity<IdentityUserToken<string>>().ToTable("UsuarioTokens");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UsuarioPlogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("PerfilRegras");          
            //um mesmo usuario pode ter varios perfis, e um perfil pode ser atribuido a varios usuarios, entao é necessario criar uma tabela de relacionamento entre usuario e perfil, que é a UsuarioPerfis
            /*
            ENTENDENDO A LOGICA TODA
            o identity tem varias tabelas, cada tabela tem uma função diferente, a tabela de usuario é a principal
            ela armazena as informações do usuario, como nome, email, senha, etc
            A tabela de perfis armazena os perfis que podem ser atribuídos aos usuarios, 
            como admin, usuario comum, etc. A tabela de usuario perfis armazena a relação entre usuario e perfil
            , ou seja, quais perfis cada usuario possui. A tabela de regras armazena as regras que podem ser atribuídas
             aos perfis, como criar receita, editar receita, etc. A tabela de perfil regras armazena a relação entre perfil e regra
             , ou seja, quais regras cada perfil possui.
            */
            #endregion
    }
}
