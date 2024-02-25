using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditon : MonoBehaviour
{
    [SerializeField] private LayerMask EnemyLayer;
    [SerializeField] private string WinScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Physics2D.OverlapCircle(transform.position, 10000f, EnemyLayer))
        {
            SceneManager.LoadScene(sceneName: WinScene);
        }
    }
}
