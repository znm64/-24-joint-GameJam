using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float followSpeed = 2f;
    [SerializeField] public Transform target;

    private Vector3 offset;
    private float shaketime;
    private float duration;
    private float mag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed*Time.deltaTime) + offset;
        if (shaketime < duration)
        {
            shaketime += Time.deltaTime;
            offset = new Vector2(Random.Range(-1f, 1f) * mag, Random.Range(-1f, 1f) * mag);
        }
        else
        {
            offset = Vector2.zero;
        }
    }

    public void Shake(float magnitude, float dur)
    {
        shaketime = 0f;
        duration = dur;
        mag = magnitude;
    }
}
