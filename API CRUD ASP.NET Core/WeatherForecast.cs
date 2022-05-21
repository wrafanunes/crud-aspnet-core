using System.ComponentModel.DataAnnotations;

namespace API_CRUD_ASP.NET_Core
{
#pragma warning disable CS1591
    /// <summary>
    /// Classe de previsão do tempo
    /// </summary>
    public class WeatherForecast
    {
        [Required]
        public DateTime Date { get; set; }
        /// <summary>
        /// Temperatura em Celsius
        /// </summary>

        public int TemperatureC { get; set; }
        /// <summary>
        /// Temperatura em graus Fahrenheit, automaticamente calculada, usando como argumento o valor da temperatura em Celsius
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        /// <summary>
        /// Propriedade anulável que sempre retorna o resumo da previsão do tempo, ou um valor nulo
        /// </summary>
        public string? Summary { get; set; }
    }
}