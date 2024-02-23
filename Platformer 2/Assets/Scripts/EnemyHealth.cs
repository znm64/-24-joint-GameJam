using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;
    [SerializeField] private AudioSource DamagedSound;
    [SerializeField] private GameObject DeathParticles;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }
        if (health == 0)
        {
            Instantiate(DeathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
    public void Damage(int amount)
    {
        health -= amount;
        //DamagedSound.Play();
    }
}
