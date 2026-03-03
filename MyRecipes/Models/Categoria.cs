

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRecipes.Models;
[Table("Categorias")] //define o nome da tabela no banco de dados, caso contrario, o nome da tabela seria o mesmo da classe, ou seja, "Categoria"

public class Categoria
{
    [Key] //define a chave primária da tabela
    public int Id { get; set; } //define a propriedade Id como chave primária da tabela, ou seja, ela será usada para identificar unicamente cada registro na tabela

    [StringLength(30)]
    [Required(ErrorMessage = "o nome é obrigatório")] //define a propriedade Nome como obrigatória, ou seja, ela não pode ser nula ou vazia
    public string Nome { get; set; } //define a propriedade Nome como string, ou
    
    [StringLength(30)]

    public string icone { get; set; } //define a propriedade icone como string, ou seja, ela pode ser nula ou vazia

    
       
}
