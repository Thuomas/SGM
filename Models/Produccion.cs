using NuGet.Protocol;

namespace SGM.Models;

public class Produccion
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public string OrdenProduccion { get; set; }

    public int ModeloId { get; set; }

    public virtual Modelo Modelo{ get; set; }

    public int Cantidad { get; set; }

    public int TrabajoId { get; set; }
    public virtual Trabajo Trabajo { get; set;}

}