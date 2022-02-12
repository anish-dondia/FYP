using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTimer : MonoBehaviour
{
    [SerializeField] float maxHealthTimer = 100f;
    [SerializeField] float currentTimer;
    [SerializeField] float damageDrop = 5f;

    float time = 0.0f;
    float period = 1f;
    float timeDropper = 1f;

    private HealthBar healthBar;
    void Awake()
    {
        this.healthBar = this.GetComponentInChildren<HealthBar>();
        this.currentTimer = this.maxHealthTimer;

        this.UpdareHealthTimer();
    }

 
    void Update()
    {
        time += Time.deltaTime;

        if (time >= period)
        {
            time = 0.0f;

            this.currentTimer -= this.timeDropper;
            this.UpdareHealthTimer();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Litter")
        {
            if(this.currentTimer > 0)
            {
                this.currentTimer -= this.damageDrop;
                this.UpdareHealthTimer();
            }
        }
    }

    void UpdareHealthTimer()
    {
        float percentHealth = (this.currentTimer / this.maxHealthTimer);
        this.healthBar.UpdateHealthTimer(percentHealth);
    }
}
