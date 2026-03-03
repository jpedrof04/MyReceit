using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyRecipes.Models;

namespace GCook.Models;

[Table("Receitas")] //pense nesse atributo como o nome da tabela no banco de dados, ou seja, ele define o nome da tabela que será criada no banco de dados para armazenar os dados da classe Receita
public class Receita  //define a classe Receita, que representa uma receita culinária, ou seja, ela tem propriedades que descrevem a receita, como nome, descrição, tempo de preparo, rendimento, dificuldade, foto, etc.
{
    [Key] //codigo praticamente conjunto do debaixo
    public int Id { get; set; } /*essas duas linhas, são pra definir cada id para cada receita*/

    [Required(ErrorMessage = "A Categoria é obrgatória")] //definição obrigatoria de categoria (que esta embaixo)
    public int CategoriaId { get; set; }
    [ForeignKey(nameof(CategoriaId))]
    public Categoria Categoria { get; set; }//como uma ponte, esse pulic caça o ID da categoria nas categorias

    [Required(ErrorMessage = " O nome é obrigatório")]
    [StringLength(100)] //define um limite de caracterest para o nome e outros
    public string Nome { get; set; }

    [StringLength(1000)]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [StringLength(30)]
    [Display(Name = "Tempo de Preparo")] //pro usuario entender
    public string TempoPreparo { get; set; } //pro codigo entender

    public int Rendimento { get; set; }

    public Dificuldade Dificuldade { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

    [Required]
    public string UsuarioId { get; set; }
    [ForeignKey(nameof(UsuarioId))] //isso liga uma tebela na outra
    public Usuario Usuario { get; set; }

    public List<Preparo> Preparo { get; set; } //a lista significa 'VARIOS'

    public List<ReceitaIngrediente> Ingredientes { get; set; }/*
    Uma receita pode ter vários ingredientes e vários passos de preparo. Então, você cria uma lista para guardar esses itens dentro da receita.
    */
    
}