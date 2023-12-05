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

    private void Awake()
    {
        SetOrbit(n);
    }

    public void SetN(int newN)
    {
        n = newN;
        SetOrbit(n);
    }

    private void SetOrbit(int orbit)
    {
        gameObject.transform.position = new Vector3(orbit * 5, 0, 0);
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
