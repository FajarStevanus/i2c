using System.Device.I2c;

namespace Device
{
  public class I2cDeviceBase
  {
    public I2cDevice Device;

    public I2cDeviceBase(I2cDevice device)
    {
      Device = device;
    }
  }
}