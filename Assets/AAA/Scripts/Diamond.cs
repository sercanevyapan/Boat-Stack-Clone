using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{

    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RidingBoat")
        {

            Destroy(this.gameObject);

            GameManager.instance.AddPoint(1);

            playerController.BoostPlayerSpeed();

        }


    }

}
