using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Properties : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI equationText;

    public const double PLANCK = 6.6262e-27;

    private int n = 1;
    private double L;

    private void Start()
    {
        SpeedControler.OnSpeedChange.AddListener(CalculateL);
        CalculateL();
    }
    private void CalculateL()
    {
        L = n * (PLANCK / (2 * Mathf.PI));
        UpdateLText();
    }
    private void UpdateLText()
    {
        equationText.SetText("<i>L</i> = n ∙ ( <i>h</i> / 2π ) ≈ " + L.ToString("0.00E0"));
    }
}
