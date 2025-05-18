using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazer_HectorEduardo.Pages
{
    public class OperacionesArregloModel : PageModel
    {
        public int[] Arreglo { get; set; } = new int[20];
        public int[] ArregloOrdenado { get; set; } = new int[20];
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public int[] Frecuencias { get; set; } = new int[101]; 
        public string ModaTexto { get; set; } = "";
        public double Mediana { get; set; }

        public void OnGet()
        {
            Random rnd = new Random();

            //suma
            for (int i = 0; i < Arreglo.Length; i++)
            {
                Arreglo[i] = rnd.Next(0, 101);
                Suma += Arreglo[i];
                Frecuencias[Arreglo[i]]++;
            }

            // Calcular promedio
            Promedio = Math.Round((double)Suma / Arreglo.Length, 2);

            // copiar  arreglo
            for (int i = 0; i < Arreglo.Length; i++)
                ArregloOrdenado[i] = Arreglo[i];

            // ordenar arreglo 
            for (int i = 0; i < ArregloOrdenado.Length - 1; i++)
            {
                for (int j = i + 1; j < ArregloOrdenado.Length; j++)
                {
                    if (ArregloOrdenado[i] > ArregloOrdenado[j])
                    {
                        int temp = ArregloOrdenado[i];
                        ArregloOrdenado[i] = ArregloOrdenado[j];
                        ArregloOrdenado[j] = temp;
                    }
                }
            }

            // calcular mediana
            int medio = ArregloOrdenado.Length / 2;
            if (ArregloOrdenado.Length % 2 == 0)
                Mediana = (ArregloOrdenado[medio - 1] + ArregloOrdenado[medio]) / 2.0;
            else
                Mediana = ArregloOrdenado[medio];

            // calcular moda
            int maxRepeticiones = 0;
            for (int i = 0; i < Frecuencias.Length; i++)
            {
                if (Frecuencias[i] > maxRepeticiones)
                {
                    maxRepeticiones = Frecuencias[i];
                }
            }

            for (int i = 0; i < Frecuencias.Length; i++)
            {
                if (Frecuencias[i] == maxRepeticiones && maxRepeticiones > 1)
                {
                    if (ModaTexto != "") ModaTexto += " y ";
                    ModaTexto += i.ToString();
                }
            }

            if (ModaTexto == "")
                ModaTexto = "no hay moda";
        }
    }
}
