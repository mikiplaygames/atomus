using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DrawCircle : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    void Start()
    {
        RenderCircle(112, 5f);
    }
    private void RenderCircle(int steps, float radius)
    {
        lineRenderer.positionCount = steps;
        for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / steps;
            float currentRadian = circumferenceProgress * 2 * Mathf.PI;
            float scaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);
            float x = scaled * radius;
            float y = yScaled * radius;
            Vector3 currentPosition = new Vector3(x, y, 0);
            lineRenderer.SetPosition(currentStep, currentPosition);
        }
    }
}
