using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthTimer;

    public void UpdateHealthTimer(float healthpercentage)
    {
        this.healthTimer.fillAmount = healthpercentage;
    }
}
