using System;
using UnityEngine;
using UnityEngine.Events;

public class SpeedControler : MonoBehaviour
{
    [SerializeField] private RectTransform spedometer;
    public static UnityEvent OnSpeedChange = new UnityEvent();
    private void Awake()
    {
        RefreshSpedometer();
    }
    public void SetSpeed(float i)
    {
        //Speed = (int)i;
        Time.timeScale = i / 1000f;
        OnSpeedChange?.Invoke();
    }
    public void RefreshSpedometer()
    {
        spedometer.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(170,-60,Time.timeScale));
    }    //170 - -60
}
