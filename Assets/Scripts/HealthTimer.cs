using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthTimer : MonoBehaviour
{
    [SerializeField] float maxHealthTimer = 100f;
    [SerializeField] float currentTimer;
    [SerializeField] float damageDrop = 5f;
    [SerializeField] float toxicAirDamage = 0.1f; 
    [SerializeField] float toxicWaterDamage = 0.5f;
    [SerializeField] float carDamage = 20f;
    [SerializeField] float food = 10f;

    [SerializeField] AudioClip eat;

    float time = 0.0f;
    float period = 1f;
    float timeDropper = 1f;

    private HealthBar healthBar;

    public List<GameObject> Food;

    void Awake()
    {

        this.healthBar = this.GetComponentInChildren<HealthBar>();
        this.currentTimer = this.maxHealthTimer;

        this.UpdateHealthTimer();

        Food = new List<GameObject>();
        Food.AddRange(GameObject.FindGameObjectsWithTag("Food"));
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
                AudioSource.PlayClipAtPoint(eat, transform.position);
            }
        }

        if(collision.collider.tag == "Car")
        {
            if (this.currentTimer > 0)
            {
                this.currentTimer -= this.carDamage;
                this.UpdateHealthTimer();
            }
        }

        if(collision.collider.tag == "Food")
        {
            if (this.currentTimer <= 150f)
            {
                this.currentTimer += this.food;
                this.UpdateHealthTimer();

                if(this.currentTimer > 149f)
                {
                    this.currentTimer = 150;
                    this.UpdateHealthTimer();
                }
            }
            AudioSource.PlayClipAtPoint(eat, transform.position);
            Food.Remove(collision.gameObject);
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
        if(this.currentTimer <= 0 || Food.Count <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    void UpdateHealthTimer()
    {
        float percentHealth = (this.currentTimer / this.maxHealthTimer);
        this.healthBar.UpdateHealthTimer(percentHealth);
    }
}
