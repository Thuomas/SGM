using System.ComponentModel.DataAnnotations;
namespace SGM.Models;

/// <summary>
/// Son los trabajos de soldadura que se le encargan al proveedor
/// cada uno con un codigo que lo identifiica, fecha y cantidad
/// Las relaciones son con Modelo (un modelo por trabajo), y con las Entregas (varias entregas 
/// de un mismo trabajo)
/// </summary>
public class Trabajo
{
    public int Id { get; set; }
    public DateOnly Fecha { get; set; }

    [Display(Name="Orden de Trabajo nº")]
    public string OrdenTrabajo { get; set; }
    
    [Display(Name = "Modelo")]
    public int ModeloId { get; set; }

    public virtual Modelo Modelo { get; set; }

    public int Cantidad { get; set; }

    //[Display(Name = "Orden de produccion")]
    //public int OrdenProduccionId { get; set; }

    // public virtual Produccion OrdenProduccion { get; set; }

    // public  List<EntregasSmt> Entregas { get; set; } 

}
