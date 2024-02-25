using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public PostProcessControls postProcessControls;
    [SerializeField] private GameObject HumanPlayer;
    [SerializeField] private GameObject DragonPlayer;
    [SerializeField] private Transform DragonTransform;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private CameraFollow cameraFollow;

    private bool Human;
    // Start is called before the first frame update
    void Start()
    {
        Human = true;
        DragonPlayer.SetActive(false);
        cameraFollow.target = HumanPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Human)
            {
                postProcessControls.EtherPostProcess();
                HumanPlayer.SetActive(false);
                DragonPlayer.SetActive(true);
                DragonTransform.position = HumanPlayer.transform.position;
                cameraFollow.target = DragonTransform;
                audioManager.Play("RealToEther");
            }
            else
            {
                postProcessControls.MainPostProcess();   
                DragonPlayer.SetActive(false);
                HumanPlayer.SetActive(true);
                HumanPlayer.transform.position = DragonTransform.position;
                cameraFollow.target = HumanPlayer.transform;
                audioManager.Play("EtherToReal");
            }
            Human = !Human;
            
        }
        if (Human){
            transform.position = HumanPlayer.transform.position;
        }
        else
        {
            transform.position = DragonTransform.position;
        }
    }
    public bool GetState()
    {
        return Human;  
    }
}
