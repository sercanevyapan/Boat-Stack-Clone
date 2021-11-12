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



    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "RightPlatform")
        {
            playerController.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 20f), Time.deltaTime * 5.0f);
        }
    }

    public void IncerementBoatVolume(float value)
    {

        //if (value > 1)
        //{
        //    float leftValue = value - 1;
        //    int boatCount = playerController.boats.Count;
        //    transform.localPosition = new Vector3(transform.localPosition.x,                      -0.5f*(boatCount-1)+ -0.25f ,transform.localPosition.z);
        //    transform.localScale = new Vector3(0.5f,transform.localScale.y,1f);
        //    playerController.CreateBoat(leftValue);


        //}else
        if (value < 0)
        {

            playerController.DestroyBoats(this);

     
        }
        else
        {
            int boatCount = playerController.boats.Count;
            transform.localPosition = new Vector3(transform.localPosition.x, -0.5f * (boatCount - 1) + -0.25f* value, transform.localPosition.z);
            transform.localScale = new Vector3(0.5f * value, transform.localScale.y, value);
        }
    }
}
