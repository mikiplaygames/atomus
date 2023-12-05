using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class PhotonControler : MonoBehaviour
{
    public static PhotonControler Instance;
    [SerializeField] GameObject photonPrefab;
    public ObjectPool<Transform> photons;
    Vector3 pos;
    private void Awake()
    {
        Instance = this;
        photons = new ObjectPool<Transform>(CreatePhoton, EnablePhoton, DisablePhoton, DestroyPhoton, false, 100, 100);
    }
    private void OnEnable()
    {
        StartCoroutine(SpawnPhoton());
    }
    private IEnumerator SpawnPhoton()
    {
        while (enabled)
        {
            photons.Get();
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    private Transform CreatePhoton()
    {
        pos = transform.position;
        return Instantiate(photonPrefab, new Vector3(pos.x, pos.y + Random.Range(-15f,15f), pos.z), Quaternion.identity).transform;
    }
    private void EnablePhoton(Transform _photon)
    {
        pos = transform.position;
        _photon.position = new Vector3(pos.x, pos.y + Random.Range(-10f,10f), pos.z);
        _photon.gameObject.SetActive(true);
        var collider = _photon.GetComponent<Collider>();
        collider.enabled = true;
    }
    private void DisablePhoton(Transform _photon)
    {
        _photon.gameObject.SetActive(false);
    }
    private void DestroyPhoton(Transform _photon)
    {
        Destroy(_photon.gameObject);
    }
}
