namespace Winxes.Models
{
    public class Winx
    {
        public int MyProperty {get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public List<string> Tipo { get; set; } = [];

        public double Altura { get; set; }

        public double Peso { get; set; }

        public string Imagem { get; set; }
    }
}