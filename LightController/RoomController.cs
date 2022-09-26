using Lights;
using Sensors;

namespace LightController
{
    public class RoomController
    {

        public List<ILight> Lights { get; } = new List<ILight>();

        public List<IMotionSensor> MotionSensors { get; } = new List<IMotionSensor>();

        public List<ISoundSensor> SoundSensors { get; } = new List<ISoundSensor>();

        public double Threshold { get; set; } = 0.5;


        int updatesBelowThreshold = 0;

        bool lightsOn = false;


        public void Run()
        {
            while (true)
            {
                Update();
                Thread.Sleep(500);
            }
        }



        public void Update()
        {
            if (Lights.Count == 0 || MotionSensors.Count == 0 || SoundSensors.Count == 0) return;


            double motionActivity = MotionSensors.Average(sensor => sensor.GetMotionActivity());

            double soundActivity = SoundSensors.Average(sensor => sensor.GetSoundActivity());

            Console.WriteLine("Motion activity: " + string.Format("{0:0.00}", motionActivity));
            Console.WriteLine("Sound activity: " + string.Format("{0:0.00}", soundActivity));


            if (motionActivity > Threshold && soundActivity > Threshold)
            {
                if (!lightsOn)
                {
                    Console.WriteLine("Lights ON");

                    lightsOn = true;

                    Lights.ForEach(light => light.TurnOn());

                    updatesBelowThreshold = 0;
                }
            }
            else if (lightsOn)
            {
                updatesBelowThreshold++;

                if (updatesBelowThreshold > 3)
                {
                    // three updates below threshold in a row
                    Console.WriteLine("Lights OFF");

                    lightsOn = false;

                    Lights.ForEach(light => light.TurnOff());
                }
            }
        }

        public RoomController(List<ILight> lights, List<IMotionSensor> motionSensors, List<ISoundSensor> soundSensors)
        {
            Lights = lights;
            MotionSensors = motionSensors;
            SoundSensors = soundSensors;
        }
    }
}
