using LightController;
using Lights;
using Sensors;
using OwnBrandCeilingLight;
using ExternalBrandFloorLamp;
using ExternalBrandFloorLampAdapter;
using OwnBrandMultiSensor;
using OwnBrandMotionSensor1;
using OwnBrandMotionSensor2;
using OwnBrandSoundSensor;
using ExternalBrandSoundSensor;
using ExternalBrandSoundSensorAdapter;


List<ILight> lights = new()
{
    new CeilingLight(),
    new CeilingLight(),
    new FloorLampAdaper(new FloorLamp()),
    new FloorLampAdaper(new FloorLamp())
};


MultiSensor multiSensor = new();


List<IMotionSensor> motionSensors = new()
{
    multiSensor,
    new MotionSensor1(),
    new MotionSensor2()  
};

List<ISoundSensor> soundSensors = new()
{
    multiSensor,
    new SoundSensor(),
    new ExternalSoundSensorAdapter(new ExternalSoundSensor())
};


RoomController lightController = new(lights, motionSensors, soundSensors);

lightController.Run();
