using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DamageDisplay : MonoBehaviour
{
    SpriteRenderer sprite;
    Color prev;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void WhenDamaged()
    {      
        StartCoroutine(animator());
        

    }

    IEnumerator animator()
    {
        prev = sprite.color;
        sprite.color = new Color (1, 0, 0, 1); 
        //implement a timer here to keep it red for e.g 0.1s
        yield return new WaitForSeconds(0.5f);
        sprite.color = prev;
    }
    
}
