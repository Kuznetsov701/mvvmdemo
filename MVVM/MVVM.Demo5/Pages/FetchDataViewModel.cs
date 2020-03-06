using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVVM.Demo5.Pages
{
    public class FetchDataViewModel : ObservableObject
    {
        HttpClient http;

        public FetchDataViewModel(HttpClient http)
        {
            this.http = http;
        }

        private WeatherForecast[] _Forecasts;
        public WeatherForecast[] Forecasts
        {
            get => _Forecasts;
            set => OnPropertyChanged(ref _Forecasts, value);
        }

        public async Task LoadDataAsync()
        {
            Forecasts = await http.GetJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }

        public class WeatherForecast
        {
            public DateTime Date { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
