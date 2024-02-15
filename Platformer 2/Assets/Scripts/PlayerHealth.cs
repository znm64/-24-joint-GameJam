using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    private int maxHealth = 5;
    [SerializeField] private AudioSource DamagedSound;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < (health / 2)-0.5f)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (i == (health / 2) - 0.5f)
            {
                hearts[i].sprite = halfHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
    public void Damage(int amount)
    {
        health -= amount;
        DamagedSound.Play();
    }
    public void Heal(int amount)
    {
        health += amount;
    }
}
