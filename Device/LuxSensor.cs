using System.Device.I2c;
using Iot.Device.Bh1750fvi;

namespace Device
{
  public class LuxSensor : I2cDeviceBase
  {
    private Bh1750fvi _device;

    public LuxSensor(int chanel, int address) : base(I2cDevice.Create(new I2cConnectionSettings(chanel, address)))
    {
      _device = new Bh1750fvi(Device);
    }

    public double Lux => _device.Illuminance.Lux;
  }
}