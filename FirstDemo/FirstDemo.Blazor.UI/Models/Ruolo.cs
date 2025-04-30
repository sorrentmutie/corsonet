

using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Blazor.UI.Models;

public class Ruolo
{
    [Required(ErrorMessage ="Attenzione il ruolo non può essere vuoto")]
    public  string Nome { get; set; } = string.Empty;
}
