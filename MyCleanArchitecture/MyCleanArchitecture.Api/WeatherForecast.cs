namespace MyCleanArchirectureApi
{
    /// <summary>
    /// Информация о погоде.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Дата показаний.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Температура цельсия.
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Температура F.
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Сумма всех значений.
        /// </summary>
        public string? Summary { get; set; }
    }
}
