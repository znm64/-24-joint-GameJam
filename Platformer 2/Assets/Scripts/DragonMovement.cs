using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{

    private float speed = 0.3f;
    private float maxSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 0.9f;
        }
        else
        {
            speed = 0.3f;
        }
    }
    void FixedUpdate()
    {
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        float dist = Vector2.Distance(transform.position, targetPos);
        float moveDistance = (dist * speed / 10);
        if (moveDistance > maxSpeed)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, maxSpeed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveDistance);
        }
    }
}