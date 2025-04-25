using System.ComponentModel.DataAnnotations;

namespace SGM.Models;

public class Entrega
{
    public int Id { get; set; }

    [Display(Name = "Fecha")]
    public DateOnly Fecha { get; set; }

    public string Remito { get; set; }

    [Display(Name = "Orden de Trabajo")]
    public int TrabajoId { get; set; }

    public virtual Trabajo OrdenTrabajo { get; set; }

    public int Cantidad { get; set; }

    public int CantidadRestante { get; set; }

}