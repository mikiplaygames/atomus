using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ElectronControler : MonoBehaviour
{
    [SerializeField] private bool increment = false;
    GameObject photon;

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
        PhotonControler.Instance.photons.Release(other.transform);
        if (increment && transform.localPosition.x < 5)
            transform.localPosition += Vector3.right;
    }
}
