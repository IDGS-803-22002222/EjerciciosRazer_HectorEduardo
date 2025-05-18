using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace EjerciciosRazer_HectorEduardo.Pages
{
    public class EvaluarExpresionModel : PageModel
    {
        

        [BindProperty]
        public double A { get; set; }
        [BindProperty]
        public double B { get; set; }
        [BindProperty]
        public double X { get; set; }
        [BindProperty]
        public double Y { get; set; }
        [BindProperty]
        public int N { get; set; }
        public double Resultado { get; set; }
        public double primerResultado { get; set; }

        public List<IteracionResultado> Iteraciones = new List<IteracionResultado>();

        public void OnGet()
        {
        }

        public void OnPost()
        {
            primerResultado = Math.Pow((A * X) + (B * Y), N);
            double suma = 0;
            for (int k = 0; k <= N; k++)
            {
                double coef = Binomial(N, k);
                double termino = coef * Math.Pow(A * X, N - k) * Math.Pow(B * Y, k);
                suma += termino;
                Iteraciones.Add(new IteracionResultado
                {
                    K = k,
                    Termino = termino,
                    SumaAcumulada = suma
                });
            }
            Resultado = suma;
            
        }



        public double Binomial(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        public double Factorial(int num)
        {
            double res = 1;
            for (int i = 2; i <= num; i++)
            {
                res *= i;
            }
               
            return res;
        }
    }
}