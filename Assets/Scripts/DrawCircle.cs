using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DrawCircle : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float radius = 2f;
    [SerializeField] private int steps = 120;

    void Start()
    {
        RenderCircle(steps, radius);
    }
    private void RenderCircle(int steps, float radius)
    {
        lineRenderer.positionCount = steps + 1;

        for (int currentStep = 0; currentStep <= steps; currentStep++)
        {
            float angle = 2 * Mathf.PI * currentStep / steps;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            Vector3 currentPosition = new Vector3(x, y, 0);
            lineRenderer.SetPosition(currentStep, currentPosition);
        }
    }
}
