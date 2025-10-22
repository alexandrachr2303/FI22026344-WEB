using System.ComponentModel.DataAnnotations;
namespace MVC.Models;

public class TheModel
{
    [Required(ErrorMessage = "Frase requerida")]
    [StringLength(25, MinimumLength = 5, ErrorMessage = "Ingrese una frase con el rango de 5 a 20 caracteres.")]
    public string? Phrase { get; set; }

    public Dictionary<char, int> Counts { get; set; } = new Dictionary<char, int>();

    public string Lower { get; set; } = string.Empty;

    public string Upper { get; set; } = string.Empty;
}
