using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ElectronControler : MonoBehaviour
{
    [SerializeField] private bool increment = false;
    private void OnEnable()
    {
        if (increment)
            StartCoroutine(Lower());
    }
    private IEnumerator Lower()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(Random.Range(0.01f, 5));
            if (transform.localPosition.x > 3)
                transform.localPosition -= Vector3.right;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (increment && transform.localPosition.x < 5)
        {
            transform.localPosition += Vector3.right;
            StartCoroutine(ReleaseAfterTime(other.transform));
        }
    }
    private IEnumerator ReleaseAfterTime(Transform other)
    {
        var rb = other.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        other.gameObject.SetActive(false);
        yield return new WaitForSeconds(Random.Range(0.1f, 3f));
        other.gameObject.SetActive(true);
        rb.AddForce(new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),0) * 1000);
    }
}
