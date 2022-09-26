using ExternalBrandFloorLamp;
using Lights;

namespace ExternalBrandFloorLampAdapter
{
    public class FloorLampAdaper : ILight
    {

        readonly FloorLamp floorLamp;

        public bool IsOn => floorLamp.Status;

        public void TurnOn()
        {
            floorLamp.Status = true;
        }

        public void TurnOff()
        {
            floorLamp.Status = false;
        }

        public FloorLampAdaper(FloorLamp floorLamp)
        {
            this.floorLamp = floorLamp;
        }

    }
}