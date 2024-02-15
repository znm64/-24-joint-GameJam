using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SoulMovement : MonoBehaviour
{
    private int AngleMovement = 0;
    private bool Tethered = false;
    private float TetherRadius = 2f;
    private float Speed = 0.02f;
    private int[] AnglePossibilities = {-1, 0, 0, 0, 0, 0, 1};
    [SerializeField] private Transform PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        AngleMovement = (AngleMovement + AnglePossibilities[Random.Range(0, AnglePossibilities.Length-1)]) % 360;
        transform.position = transform.position + new Vector3(Speed * Mathf.Cos(AngleMovement), Speed * Mathf.Sin(AngleMovement), 0);
        if (Tethered)
        {
            Vector3 pos = transform.position - PlayerTransform.position;
            if (pos.magnitude > TetherRadius)
            {
                transform.position += Vector3.MoveTowards(pos, Vector3.zero, pos.magnitude-TetherRadius)-pos;
            }
        }
        else if (Vector2.Distance(PlayerTransform.position, transform.position) < TetherRadius)
        {
            Tethered = true;
        }
    }
}
