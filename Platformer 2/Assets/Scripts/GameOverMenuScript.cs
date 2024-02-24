using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenuScript : MonoBehaviour
{
    [SerializeField] public GameObject gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reincarnateButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void returnToMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
