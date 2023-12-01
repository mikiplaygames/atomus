using UnityEngine;

public class ElectronControler : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    GameObject photon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layerMask)
        {
            photon = other.gameObject;
            photon.SetActive(false);
        }
    }
}
