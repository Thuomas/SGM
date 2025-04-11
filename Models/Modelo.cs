namespace SGM.Models;
public class Modelo
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual List<Trabajo>? Trabajos { get; set;}
    
    public virtual List<ControlEquipo>? ControlEquipos { get; set;}

}
