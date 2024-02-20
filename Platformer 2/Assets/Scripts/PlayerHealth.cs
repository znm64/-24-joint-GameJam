using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private AudioSource DamagedSound;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
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
        int heart = Mathf.FloorToInt((health / 2));
        Debug.Log(heart);
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < heart)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (i == heart)
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
        //DamagedSound.Play();
    }
    public void Heal(int amount)
    {
        health += amount;
    }
}
