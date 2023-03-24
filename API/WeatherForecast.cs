namespace API;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}


// "StripeSettings": {
  //   "Publishablekey": "pk_test_BFHIkQb9wGxwolmmXv9aEoQB00sW3ge36w",
  //   "Secretkey": "sk_test_RLIKsZDOqyitymdB6z0t9JpL00mYMfgsbT",
  //   "WhSecret": "whsec_8b51133ee6e25efe0bf3ff6655ebe4ceb4b1f6357943d86752ab4b8757e005b4"
  // }