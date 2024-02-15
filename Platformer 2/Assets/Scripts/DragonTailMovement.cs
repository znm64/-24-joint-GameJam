using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTailMovement : MonoBehaviour
{
    [SerializeField] private Transform prev;

    [SerializeField] private float dist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, prev.position - transform.position);
        float currentDist = Vector2.Distance(transform.position, prev.position);
        if (currentDist > dist)
        {
            transform.position = Vector2.MoveTowards(transform.position, prev.position, currentDist - dist);
        }
    }
}
