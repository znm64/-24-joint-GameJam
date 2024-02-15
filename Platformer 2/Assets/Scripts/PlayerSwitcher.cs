using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject HumanPlayer;
    [SerializeField] private GameObject DragonPlayer;

    private bool Human;
    private Transform Follow;
    // Start is called before the first frame update
    void Start()
    {
        Human = true;
        DragonPlayer.SetActive(false);
        FindObjectOfType<Camera>().GetComponent<CameraFollow>().target = HumanPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Human)
            {
                HumanPlayer.SetActive(false);
                DragonPlayer.SetActive(true);
                FindObjectOfType<Camera>().GetComponent<CameraFollow>().target = DragonPlayer.transform;
            }
            else
            {
                DragonPlayer.SetActive(false);
                HumanPlayer.SetActive(true);
                FindObjectOfType<Camera>().GetComponent<CameraFollow>().target = HumanPlayer.transform;
            }
            
        }
        if (Human){
            transform.position = HumanPlayer.transform.position;
        }
        else
        {
            transform.position = DragonPlayer.transform.position;
        }
    }
}
