using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuScript : MonoBehaviour
{

    [SerializeField] public GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void optionsButton()
    {
        // open an options menu if desired -- no new scene required for this
    }
}
