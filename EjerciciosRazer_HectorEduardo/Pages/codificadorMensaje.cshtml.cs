using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazer_HectorEduardo.Pages
{
    public class codificadorMensajeModel : PageModel
    {
        [BindProperty]
        public string MensajeOriginal { get; set; }
        [BindProperty]
        public int N { get; set; } = 3;
        public string MensajeCodificado { get; set; }
        public string MensajeDecodificado { get; set; }

        public void OnPostCodificar()
        {
            MensajeCodificado = CodificarCesar(MensajeOriginal, N);
        }

        public void OnPostDecodificar()
        {
            MensajeDecodificado = CodificarCesar(MensajeOriginal, 26 - (N % 26));
        }

        private string CodificarCesar(string texto, int n)
        {
            string abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string resultado = "";
            texto = texto.ToUpper();

            for (int i = 0; i < texto.Length; i++)
            {
                char c = texto[i];
                if (abecedario.Contains(c))
                {
                    int pos = abecedario.IndexOf(c);
                    int nuevaPos = (pos + n) % abecedario.Length;
                    resultado += abecedario[nuevaPos];
                }
                else
                {
                    resultado += c;
                }
            }
            return resultado;
        }
    }
}
