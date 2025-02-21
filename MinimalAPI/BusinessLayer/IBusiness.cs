namespace MinimalAPI.BusinessLayer;

public interface IBusiness
{
    Task<IEnumerable<WeatherForecast>> Getweatherforecast();
}
