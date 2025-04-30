
using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Blazor.UI.Models;

public class RuoloUtente
{
    [Required(ErrorMessage = "Email non corretta")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Ruolo non corretto")]
    public string Ruolo { get; set; } = string.Empty;

}
