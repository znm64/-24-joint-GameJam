using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class SoulMovement : MonoBehaviour
{
    private int walkDuration = 20;
    private int walkTime;
    private int AngleMovement = 0;
    private bool Tethered = false;
    private float TetherRadius = 2f;
    private float Speed = 0.02f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private GameObject PurifiedSoldier;    
    [SerializeField] private PlayerSwitcher playerSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        walkTime = walkDuration;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = !playerSwitcher.GetState();
    }
    private void FixedUpdate()
    {
        if (walkTime > 2) { walkTime--; }

        if (Random.Range(0, walkTime) == 0)
        {
            walkTime = walkDuration;
            AngleMovement += Random.Range(-1, 2);
        }

        transform.position += new Vector3(Speed * Mathf.Cos(AngleMovement), Speed * Mathf.Sin(AngleMovement), 0);
        if (Tethered)
        {
            float dist = (transform.position - PlayerTransform.position).magnitude;
            if (dist > TetherRadius)
            {
                transform.position = Vector3.MoveTowards(transform.position, PlayerTransform.position, dist-TetherRadius);
            }

            foreach (Collider2D col in Physics2D.OverlapCircleAll(transform.position, TetherRadius))
            {
                if ((col.gameObject).GetType().Name == "CorruptedSoldier")
                {
                    Instantiate(PurifiedSoldier, col.transform.position, Quaternion.identity);
                    Destroy(col.gameObject);
                    Destroy(gameObject);
                }
            }
        }
        else if (Vector2.Distance(PlayerTransform.position, transform.position) < TetherRadius)
        {
            Tethered = true;
        }
    }
}
