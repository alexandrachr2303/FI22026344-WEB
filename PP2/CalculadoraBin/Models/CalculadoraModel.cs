using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CalculadoraBin.Models
{
    public class CalculadoraModel
    {
        // Input binario 1
        [Required(ErrorMessage = "El primer número binario es obligatorio.")]
        [RegularExpression("^[01]+$", ErrorMessage = "Solo se permiten 0 y 1.")]
        [StringLength(8, MinimumLength = 2, ErrorMessage = "La longitud debe ser 2,4,6 u 8.")]
        public string Binario1 { get; set; } = "";

        // Input binario 2
        [Required(ErrorMessage = "El segundo número binario es obligatorio.")]
        [RegularExpression("^[01]+$", ErrorMessage = "Solo se permiten 0 y 1.")]
        [StringLength(8, MinimumLength = 2, ErrorMessage = "La longitud debe ser 2,4,6 u 8.")]
        public string Binario2 { get; set; } = "";

        // Resultados
        public string Bin1Byte => Binario1.PadLeft(8, '0');
        public string Bin2Byte => Binario2.PadLeft(8, '0');

        public string And { get; set; } = "";
        public string Or { get; set; } = "";
        public string Xor { get; set; } = "";
        public string Suma { get; set; } = "";
        public string Multiplicacion { get; set; } = "";

        // Métodos de conversión a otras bases
        public string BinToDecimal(string bin) => Convert.ToInt32(bin, 2).ToString();
        public string BinToOctal(string bin) => Convert.ToString(Convert.ToInt32(bin, 2), 8);
        public string BinToHex(string bin) => Convert.ToString(Convert.ToInt32(bin, 2), 16).ToUpper();

        // Validación de longitud múltiplo de 2
        public bool EsLongitudValida(string bin) => bin.Length % 2 == 0;

        // Validación completa
        public bool Validar(out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(Binario1) || string.IsNullOrEmpty(Binario2))
            {
                error = "Los dos campos son obligatorios.";
                return false;
            }

            Regex regex = new Regex("^[01]+$");
            if (!regex.IsMatch(Binario1) || !regex.IsMatch(Binario2))
            {
                error = "Solo se permiten los caracteres 0 y 1.";
                return false;
            }

            if (Binario1.Length > 8 || Binario2.Length > 8)
            {
                error = "La longitud máxima permitida es 8.";
                return false;
            }

            if (!EsLongitudValida(Binario1) || !EsLongitudValida(Binario2))
            {
                error = "La longitud debe ser múltiplo de 2 (2,4,6 u 8).";
                return false;
            }

            return true;
        }

        // Cálculo de todas las operaciones
        public void CalcularOperaciones()
        {
            int a = Convert.ToInt32(Binario1, 2);
            int b = Convert.ToInt32(Binario2, 2);

            // Operaciones binarias
            And = Convert.ToString(a & b, 2).PadLeft(8, '0');
            Or = Convert.ToString(a | b, 2).PadLeft(8, '0');
            Xor = Convert.ToString(a ^ b, 2).PadLeft(8, '0');

            // Operaciones aritméticas
            Suma = Convert.ToString(a + b, 2).PadLeft(8, '0');
            Multiplicacion = Convert.ToString(a * b, 2).PadLeft(8, '0');
        }
    }
}