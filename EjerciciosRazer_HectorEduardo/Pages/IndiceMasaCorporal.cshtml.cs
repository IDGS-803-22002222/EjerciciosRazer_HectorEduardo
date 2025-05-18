using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazer_HectorEduardo.Pages
{
    public class IndiceMasaCorporalModel : PageModel
    {
        [BindProperty]
        public double Peso { get; set; }

        [BindProperty]
        public double Altura { get; set; }

        public double IMC { get; set; }
        public string Clasificacion { get; set; } = string.Empty;
        public string ImagenRecomendacion { get; set; } = string.Empty;


        public void OnPost()
        {
            if (Altura > 0)
            {
                IMC = Peso / (Altura * Altura);
                Clasificacion = ObtenerClasificacion(IMC);
                ImagenRecomendacion = ObtenerImagen(Clasificacion);
            }
        }

        private string ObtenerClasificacion(double imc)
        {
            if (imc < 18)
                return "Peso Bajo";
            if (imc < 25)
                return "Peso Normal";
            if (imc < 27)
                return "Sobre peso";
            if (imc < 30)
                return "Obesidad grado I";
            if (imc < 40)
                return "Obesidad grado II";
            return "Obesidad grado III";
        }

        private string ObtenerImagen(string clasificacion)
        {
            return clasificacion switch
            {
                "Peso Bajo" => "/img/peso_bajo.png",
                "Peso Normal" => "/img/peso_normal.png",
                "Sobre peso" => "/img/sobrepeso.png",
                "Obesidad grado I" => "/img/obesidad1.png",
                "Obesidad grado II" => "/img/obesidad2.png",
                "Obesidad grado III" => "/img/obesidad3.png",
                _ => "/img/default.png"
            };
        }
    }
}