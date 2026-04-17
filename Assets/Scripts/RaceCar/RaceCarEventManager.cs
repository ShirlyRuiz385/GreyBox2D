
using Unity.VisualScripting;

public static class RaceCarEventManager
{
    public delegate void CarAction(float value);
    public static event CarAction OnChangeSpeed;

    public static void ChangeSpeed(float value)
    {
        OnChangeSpeed?.Invoke(value);
    }
}
