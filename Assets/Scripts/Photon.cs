using UnityEngine;

public class Photon : MonoBehaviour
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.right * 1000);
    }
}
