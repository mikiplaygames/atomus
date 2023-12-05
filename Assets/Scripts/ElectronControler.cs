using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ElectronControler : MonoBehaviour
{
    [SerializeField] private bool increment = false;
    [SerializeField] private Properties properties;
    private void OnTriggerEnter(Collider other)
    {
        if (increment && transform.localPosition.x < 6)
        {
            transform.localPosition += Vector3.right;
            StartCoroutine(ReleaseAfterTime(other.transform));
        }
        else
            PhotonControler.Instance.photons.Release(other.transform);
    }
    private IEnumerator ReleaseAfterTime(Transform other)
    {
        var rb = other.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        properties.SetN((int)transform.localPosition.x - 1);
        other.gameObject.SetActive(false);
        yield return new WaitForSeconds(Random.Range(0.01f, 5f));
        transform.localPosition -= Vector3.right;
        properties.SetN((int)transform.localPosition.x - 1);
        other.gameObject.SetActive(true);
        rb.AddForce(new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),0) * 1000);
    }
}
