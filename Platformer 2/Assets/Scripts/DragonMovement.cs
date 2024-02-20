using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float speed = 3f;
    //private float maxSpeed = 1f;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 9f;
        }
        else
        {
            speed = 3f;
        }
    }
    void FixedUpdate()
    {
        /*targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        float dist = Vector2.Distance(transform.position, targetPos);
        if (((targetPos - transform.position) * speed).magnitude > maxSpeed)//moveDistance > maxSpeed)
        {
            //transform.position = Vector3.MoveTowards(transform.position, targetPos, maxSpeed);
            Debug.Log("Limit");
            rb.velocity = (targetPos - transform.position) * speed;
        }
        else
        {
            //transform.position = Vector3.MoveTowards(transform.position, targetPos, moveDistance);
            rb.velocity = (targetPos - transform.position) * speed;
            Debug.Log("No Limit");
        }*/
        /*float angle = Vector2.SignedAngle((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized, Vector2.zero) * Mathf.Deg2Rad;
        rb.velocity = new Vector2(speed * Mathf.Cos(angle), speed * Mathf.Sin(angle));*/

        // HELP IVE TRIED FUCKING EVERYTHING AAAAA
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        Vector2 moveDir = targetPos - transform.position;
        rb.velocity = moveDir.normalized * speed;
    }
}
