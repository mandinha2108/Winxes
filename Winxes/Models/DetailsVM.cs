namespace Winxes.Models;

public class DetailsVM 
{
    public Winx Anterior { get; set; }
    public Winx Atual { get; set; }
    public Winx Proximo { get; set; }
    public List<Tipo> Tipos { get; set; }
}