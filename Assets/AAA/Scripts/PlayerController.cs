using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    public float limitX, runningSpeed, xSpeed;

    public GameObject ridingBoatPrefab;
    public List<RidingBoat> boats;


    private void Awake()
    {
        IncrementBoatVolume(1f);

    }

    private void OnCollisionEnter(Collision collision)
    {

        PlayerSlope(collision);

       
    } 

    private void PlayerSlope(Collision collision)
    {
        if (collision.transform.tag == "RightPlatform")
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 15f), 1f);
        }
        if (collision.transform.tag == "Platform")
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0f), 1f);
        }
        if (collision.transform.tag == "LeftPlatform")
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -15f), 1f);
        }
    }

   
    void FixedUpdate()
    {
       
            PlayerControl();
        
        
        
    }

    private void PlayerControl()
    {
        float newX;
        float touchXDelta = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
        
            touchXDelta = Input.GetTouch(0).deltaPosition.x ;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

    

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed* Time.deltaTime);
        transform.position = newPosition;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Add Boat")
        {
            IncrementBoatVolume(1f);
            Destroy(other.gameObject);
            
        }
        if (other.tag == "Trap" || other.tag == "Wall")
        {
            IncrementBoatVolume(-1f);
            if (boats.Count == 0)
            {

                GameManager.instance.LoseGame();
            }
        }

        if (other.tag == "FinishLevel")
        {
            GameManager.instance.isLevelFinish = true;
            GameManager.instance.LevelTotalPoint(boats.Count);

         
            
        }

        if (other.tag=="FinishWall")
        {
            IncrementBoatVolume(-1f);
            if ( boats.Count <= 0)
            {
                GameManager.instance.FinishLevel();
             

            }
        }
    }

    public void IncrementBoatVolume(float value)
    {
      
            if (value>0)
            {
                CreateBoat(value);
            }
      
        else if(value<0 && boats.Count!=0)
        {
            boats[boats.Count - 1].IncerementBoatVolume(value);
         
        }

    }

    public void CreateBoat(float value)
    {
        RidingBoat createdBoat = Instantiate(ridingBoatPrefab, transform).GetComponent<RidingBoat>();

        boats.Add(createdBoat);
        createdBoat.IncerementBoatVolume(value);
     
    }

    public void DestroyBoats(RidingBoat boat)
    {
        boats.Remove(boat);
        Destroy(boat.gameObject);

  
    }


    public void PlayerStartPosition()
    {
      
        transform.localPosition = new Vector3(0, 0.75f, -23.7999992f);
        IncrementBoatVolume(1f);
        limitX = 3;
    }


    public void BoostPlayerSpeed()
    {
        runningSpeed = 15;
        StartCoroutine(NormalPlayerSpeed());
    }

    IEnumerator NormalPlayerSpeed()
    {
        yield return new WaitForSecondsRealtime(2f);
        runningSpeed = 10;
    }
    

}
