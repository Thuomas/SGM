using System.ComponentModel.DataAnnotations;

namespace SGM.Models;

public class InsumoCritico
{
    public int Id { get; set; }

    public string Nombre { get; set; }
    
    public string Descripcion { get; set; }

    /// <summary>
    /// TODO cuando genere los Registros de Control, hacer que tenga una lista de Registros de Control
    /// 
    /// public virtual List<RegistroControl>? Registros { get; set;}
    /// </summary>



}
