using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;
using WeatherDataAPI.Models;
using WeatherDataAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly OpenWeatherApi _openWeatherApi;
        private readonly OutputFile _outputFile;
        private readonly string outputFilePath = @"..\WeatherDataAPI\Output\" + DateTime.Now.ToString("MM-dd-yyyy") + ".txt";
        private readonly string cityFilePath = @"..\WeatherDataAPI\InputFile\\\CityList.csv";

        public WeatherController(OpenWeatherApi openWeatherApi, OutputFile outputFile)
        {
            this._openWeatherApi = openWeatherApi;
            this._outputFile = outputFile;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            try
            {
                using var reader = new StreamReader(cityFilePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                
                    // Read records into a collection of GetRecords<City>().ToList()
                    var records = csv.GetRecords<City>().ToList(); 

                    if (System.IO.File.Exists(outputFilePath))
                    {
                        System.IO.File.Delete(outputFilePath);

                        //loop through the city list and capture the weather data on the Output file.
                        if (records.Count > 0)
                        {
                            foreach (City record in records)
                            {
                                var weather = await _openWeatherApi.GetWeatherAsync(record.CityName);
                                _outputFile.CreateWeatherFile(weather);
                            }
                            using var readerOutputFile = new StreamReader(outputFilePath);
                            string v = readerOutputFile.ReadToEnd();
                            return Ok(v);
                        }

                        else
                        {
                            return BadRequest("City list is empty. please provide the list of cities");
                        }
                        
                    }

                    else
                    {
                        if (records.Count > 0)
                        {
                            foreach (City record in records)
                            {
                                var weather = await _openWeatherApi.GetWeatherAsync(record.CityName);
                                _outputFile.CreateWeatherFile(weather);
                            }
                            using var readerOutputFile = new StreamReader(outputFilePath);
                            string v = readerOutputFile.ReadToEnd();
                            return Ok(v);
                        }

                        else
                        {
                            return BadRequest("City list is empty. please provide the list of cities");
                        }

                    }
                
            }
            catch (Exception)
            {
                throw;
            }
                
        }

        
    }
}
