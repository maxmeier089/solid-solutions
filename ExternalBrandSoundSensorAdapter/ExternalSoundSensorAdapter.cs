using ExternalBrandSoundSensor;
using Sensors;

namespace ExternalBrandSoundSensorAdapter
{
    public class ExternalSoundSensorAdapter : ISoundSensor
    {

        private readonly ExternalSoundSensor soundSensor;

        public double GetSoundActivity()
        {
            return ((double)soundSensor.ReadSoundLevel()) / 10.0;
        }

        public ExternalSoundSensorAdapter(ExternalSoundSensor soundSensor)
        {
            this.soundSensor = soundSensor;
        }

    }
}
