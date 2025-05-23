using System.IO;

namespace WeatherDataAPI.Services
{
    public class OutputFile
    {
        private readonly string path = @"..\WeatherDataAPI\Output\" + DateTime.Now.ToString("MM-dd-yyyy") + ".txt";
        public void CreateWeatherFile(string weatherData)
        {
            try
            {
                File.AppendAllText(path, weatherData);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
