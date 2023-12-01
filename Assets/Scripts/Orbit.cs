using UnityEngine;

public class Orbit : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(Vector3.zero, transform.up, SpeedControler.Speed * Time.deltaTime);
    }
}
