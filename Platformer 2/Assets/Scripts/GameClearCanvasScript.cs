using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearCanvasScript : MonoBehaviour
{
    [SerializeField] public GameObject gameClearCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
