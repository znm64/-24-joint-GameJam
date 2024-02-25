using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private AudioSource DamagedSound;
    public DamageDisplay damageDisplayer;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public PostProcessControls postProcessControls;
    public bool EnableVignettePP;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        UpdatePP();
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
        int heart = health;
        for (int i = 0; i < hearts.Length; i++)
        {
            if ((i+1) <= heart/2)
            {
                hearts[i].sprite = fullHeart;
            }
            else if ((i+0.5f) == (float) heart/2)
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
        UpdatePP();
        if (health <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
        }
        //damageDisplayer.WhenDamaged();
        StartCoroutine(addCA());
    }
    IEnumerator addCA()
    {
        for (float i = 0f; i < 1f; i+=0.04f)
        {
            postProcessControls.AdjustCA(i);
            yield return new WaitForSeconds(0.005f);
        }
        for (float i = 1f; i > 0f; i-=0.04f)
        {
          postProcessControls.AdjustCA(i);
          yield return new WaitForSeconds(0.005f);
        }
    }    
    public void Heal(int amount)
    {
        health += amount;
        UpdatePP();
    }
    public void UpdatePP()
    {
        if (EnableVignettePP)
        {
            //sorry i'm aware thats there's defo a better way to convert these vars on the line
            float a = health;
            float b = maxHealth;
            postProcessControls.AdjustVignette(0.45f*(1f-(a/b)));
        }
    }
}
