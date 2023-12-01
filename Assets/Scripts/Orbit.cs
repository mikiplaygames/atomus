using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;

    void Update()
    {
        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
    }
}
