namespace SGM.Models;
public class ControlEquipo
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public int ModeloId { get; set; }

    public virtual Modelo Modelo { get; set; }

}