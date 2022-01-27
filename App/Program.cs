using System;
using System.Threading;
using Device;
using Timer = System.Timers.Timer;

namespace App
{
  class Program
  {
    static void Main(string[] args)
    {
      var sygnal = new ManualResetEventSlim(false);
      if (args.Length < 2)
      {
        PrintHowTo();
        return;
      }
      
      if (!int.TryParse(args[0], System.Globalization.NumberStyles.HexNumber, null,out int luxAddres))
      {
        PrintHowTo();
        return;
      }
      
      
      if (!int.TryParse(args[1], System.Globalization.NumberStyles.HexNumber, null,out int temperatureAddress))
      {
        PrintHowTo();
        return;
      }

      Console.WriteLine($"lux {luxAddres}, temperature {temperatureAddress}");
      
      var lux = new LuxSensor(1,luxAddres);
      var temperature = new TemperatureSensor(1, temperatureAddress);
      
      var timer = new Timer(200);
      
      timer.Elapsed += (sender, eventArgs) =>
      {
        Console.WriteLine($"{DateTime.Now}, {lux.Lux} Lux, object {temperature.ObjectTemperature} Celcius, ambient {temperature.AmbientTemperature} Celcius");
      };
      
      timer.Start();

      sygnal.Wait();
    }

    static void PrintHowTo()
    {
      Console.WriteLine("./AppName lux-address temperature-address");
      Console.WriteLine("./AppName 23 5a");
    }
  }
}