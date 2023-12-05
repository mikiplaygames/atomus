using System;
using UnityEngine;
using UnityEngine.Events;

public class SpeedControler : MonoBehaviour
{
    [SerializeField] private RectTransform spedometer;
    public static int Speed = 500;
    public static UnityEvent OnSpeedChange = new UnityEvent();
    private void Awake()
    {
        RefreshSpedometer();
    }
    public void SetSpeed(float i)
    {
        Speed = (int)i;
        OnSpeedChange?.Invoke();
    }
    public void RefreshSpedometer()
    {
        spedometer.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(170,-60,Speed/1000f));
    }    //170 - -60
}
