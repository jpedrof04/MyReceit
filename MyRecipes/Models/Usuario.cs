
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MyRecipes.Models;


public class Usuario : IdentityUser //define a classe Usuario que herda da classe IdentityUser, ou seja, ela tem todas as propriedades e métodos da classe IdentityUser, além de poder adicionar novas propriedades e métodos
{
    [Required]
    [StringLength(100)]
    
    public string Nome { get; set;} //define a propriedade Name como string, ou seja, ela pode ser nula ou vazia
    [DataType(DataType.Date)]
    public DateTime? DataNascimento { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }
}
