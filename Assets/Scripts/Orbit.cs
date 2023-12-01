using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float speed = 10f;
    public bool enableSetter = false;
    public int i = 0;
    private Vector3 upper;
    private void OnGUI()
    {
        if (enableSetter)
            if (GUI.Button(new Rect(300, 10, 150, 100), "sample next"))
                i = (i + 1) % 3;
    }
    void Update()
    {
        switch (i)
        {
            case 0:
                transform.RotateAround(Vector3.zero, transform.up, speed * Time.deltaTime);
                break;
            case 1:
                transform.RotateAround(Vector3.zero, transform.right, speed * Time.deltaTime);
                break;
            case 2:
                transform.RotateAround(Vector3.zero, transform.forward, speed * Time.deltaTime);
                break;
        }
    }
}
