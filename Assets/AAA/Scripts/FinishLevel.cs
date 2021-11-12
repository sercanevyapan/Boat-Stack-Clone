using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
     
        if (other.tag=="Player")
        {
            GameManager.instance.isLevelFinish = true;
            GameManager.instance.LevelTotalPoint(playerController.boats.Count);
            playerController.limitX = 0;
        }
       

    }
}
