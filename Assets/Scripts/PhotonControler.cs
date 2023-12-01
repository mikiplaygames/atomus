using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhotonControler : MonoBehaviour
{
    public GameObject electron;
    public List<Transform> electrons;
    
    public void Count(int i)
    {
        if (i>1)
            electrons.Add(Instantiate(electron, new Vector3(0, 0, 0), Quaternion.identity).transform);
        else
        {
            Destroy(electrons[^1]);
            electrons.RemoveAt(electrons.Count - 1);
        }
    }
}
