using UnityEngine;

public class SpeedControler : MonoBehaviour
{
    public static int Speed = 1;

    public void SetSpeed(float i)
    {
        Speed = (int)i;
    }
}
