using System.ComponentModel.DataAnnotations;

namespace SGM.Models;

public class Observacion
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    [Display(Name = "Version de firmware")]
    public int FirmwareVersion { get; set; }
    
    public string Grabador { set; get; }

    [Display(Name = "N° Serie Grabador")]
    public string NumSerieGrabador { get; set; }
    
    /// <summary>
    /// TO DO: Cuando genere el registro de control, agregar a cada registro 
    /// la opcion de ocmpletar estos campos si son necesarios
    /// </summary>
    /// 
    /*[Display(Name = "V(mm)/Amp")]
    public double Amp { get; set; }

    public int Bpm { get; set; }*/

    public string Simulador  { get; set; }

    [Display(Name = "N° Serie Simulador")]
    public int NumSerieSimulador { get; set; }

    [Display(Name = "Software de analisis")]
    public int SoftAnalisis { get; set; }

}
