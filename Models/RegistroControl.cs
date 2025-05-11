using System.ComponentModel.DataAnnotations;

namespace SGM.Models;

public class RegistroControl
{
    public int Id { get; set; }

    [Display(Name = "Fecha")]
    public DateOnly Fecha { get; set; }


}