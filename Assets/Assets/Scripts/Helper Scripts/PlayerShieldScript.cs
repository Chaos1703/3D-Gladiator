using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldScript : MonoBehaviour
{
    private HealthScript healthScript;

    void Awake()
    {
        healthScript = GetComponent<HealthScript>();
    }

    public void ActivateShield(bool shieldActive)
    {
        healthScript.shieldActivated = shieldActive;
    }
}
