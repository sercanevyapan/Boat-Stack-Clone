using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidingBoat : MonoBehaviour
{

    private PlayerController playerController;
    

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    public void IncerementBoatVolume(float value)
    {

        if (value < 0)
        {

            playerController.DropBoats(this);
          

        }
        else
        {
            int boatCount = playerController.boats.Count;
            transform.localPosition = new Vector3(transform.localPosition.x, -0.5f * (boatCount - 1) + -0.25f* value, transform.localPosition.z);
            transform.localScale = new Vector3(0.5f * value, transform.localScale.y, value);
        }
    }
}
