using UnityEngine;

public class Orbit : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, transform.forward, 10);
    }
}
