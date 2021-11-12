using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishXWalls : MonoBehaviour
{

    private PlayerController playerController;

    private void Start()
    {

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerController.IncrementBoatVolume(-1f);
        if (other.tag=="Player"&& playerController.boats.Count<=0)
        {
            GameManager.instance.FinishLevel();
           
        }
    }
}
