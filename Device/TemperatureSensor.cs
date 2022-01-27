using System.Device.I2c;
using Iot.Device.Mlx90614;

namespace Device
{
  public class TemperatureSensor : I2cDeviceBase
  {
    private Mlx90614 _device;

    public TemperatureSensor(int chanel, int address) : base(
      I2cDevice.Create(new I2cConnectionSettings(chanel, address)))
    {
      _device = new Mlx90614(base.Device);
    }

    public double ObjectTemperature => _device.ReadObjectTemperature().DegreesCelsius;
    public double AmbientTemperature => _device.ReadAmbientTemperature().DegreesCelsius;
  }
}