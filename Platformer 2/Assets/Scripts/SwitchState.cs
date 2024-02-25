using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwitchState : MonoBehaviour
{
    [SerializeField] private PlayerSwitcher playerSwitcher;
    SpriteRenderer sprite;
    Color defaultcolor;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        defaultcolor = sprite.color;

    }
    void Update()
    {
        if (! playerSwitcher.GetState())
        {
            ToEther();
        }
        else
        {
            ToNormal();
        }
    }

    public void ToEther()
    {      
        sprite.color = new Color(0.2f, 0.2f, 0.2f, 1); 
    }

    public void ToNormal()
    {
        sprite.color = defaultcolor;
    }  
}

