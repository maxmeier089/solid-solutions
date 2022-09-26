namespace Lights
{
    public interface ILight
    {

        bool IsOn { get; }

        void TurnOn();

        void TurnOff();

    }
}
