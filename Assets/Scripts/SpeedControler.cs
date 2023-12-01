using System;
using UnityEngine;

public class SpeedControler : MonoBehaviour
{
    [SerializeField] private RectTransform spedometer;
    public static int Speed = 1;
    private void Awake()
    {
        RefreshSpedometer();
    }
    public void SetSpeed(float i)
    {
        Speed = (int)i;
    }
    public void RefreshSpedometer()
    {
        spedometer.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(170,-60,Speed/1000f));
    }    //170 - -60
}
