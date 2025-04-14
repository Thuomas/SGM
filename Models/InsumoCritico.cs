using System.ComponentModel.DataAnnotations;

namespace SGM.Models;

public class InsumoCritico
{
    public int Id { get; set; }

    public string Nombre { get; set; }
    
    [Required]
    [Display(Name = "Código de Equipo")]
    [RegularExpression(@"^[A-Z]{2,3}-[A-Z](0[1-9]|1[0-2])[0-9]{2}$",
            ErrorMessage = "El formato debe ser por ejemplo: DK-A0425. Usa 2 o 3 letras, un guion, una letra, y luego MMYY.")]
    public string Lote { get; set; }

    public string? Observacion { get; set; }

    /// <summary>
    /// TODO cuando genere los Registros de Control, hacer que tenga una lista de Registros de Control
    /// 
    /// public virtual List<RegistroControl>? Registros { get; set;}
    /// </summary>



}
