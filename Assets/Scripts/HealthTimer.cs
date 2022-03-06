using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthTimer : MonoBehaviour
{
    [SerializeField] float maxHealthTimer = 100f;
    [SerializeField] float currentTimer;
    [SerializeField] float damageDrop = 5f;
    [SerializeField] float toxicAirDamage = 0.1f; //NOT WORKING GET HELP
    [SerializeField] float toxicWaterDamage = 0.5f;

    float time = 0.0f;
    float period = 1f;
    float timeDropper = 1f;

    private HealthBar healthBar;
    void Awake()
    {
        this.healthBar = this.GetComponentInChildren<HealthBar>();
        this.currentTimer = this.maxHealthTimer;

        this.UpdateHealthTimer();
    }

 
    void Update()
    {
        time += Time.deltaTime;

        if (time >= period)
        {
            time = 0.0f;

            this.currentTimer -= this.timeDropper;
            this.UpdateHealthTimer();
        }

        death();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Litter")
        {
            if(this.currentTimer > 0)
            {
                this.currentTimer -= this.damageDrop;
                this.UpdateHealthTimer();
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag =="Toxic Air")
        {
            if(this.currentTimer > 0)
            {
                this.currentTimer -= this.toxicAirDamage;
                this.UpdateHealthTimer();
            }
        }

        if(other.tag == "Toxic Water")
        {
            if (this.currentTimer > 0)
            {
                this.currentTimer -= this.toxicWaterDamage;
                this.UpdateHealthTimer();
            }
        }
    }

    void death()
    {
        if(this.currentTimer <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    void UpdateHealthTimer()
    {
        float percentHealth = (this.currentTimer / this.maxHealthTimer);
        this.healthBar.UpdateHealthTimer(percentHealth);
    }
}
