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
            var pos = transform.position;
            Debug.Log(" new Vector3(pos.x, pos.y + Random.Range(-15f,15f), pos.z) = " +  new Vector3(pos.x, pos.y + Random.Range(-15f,15f), pos.z));
            photons.Get().position = new Vector3(pos.x, pos.y + Random.Range(-15f,15f), pos.z);
            yield return new WaitForSeconds((1001f - SpeedControler.Speed) / 700f);
        }
    }
    
    private Transform CreatePhoton()
    {
        return Instantiate(photonPrefab).transform;
    }
    private void EnablePhoton(Transform _photon)
    {
        _photon.gameObject.SetActive(true);
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
