using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Current;

    public float limitX;

    public float runningSpeed;
    public float xSpeed;
    private float _currentRunningSpeed;

   
    public GameObject ridingBoatPrefab;
    public List<RidingBoat> boats;

  

    // Start is called before the first frame update
    void Start()
    {
      
        Current = this;
        _currentRunningSpeed = runningSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float newX = 0;
        float touchXDelta = 0;
        if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width; 
        }else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + _currentRunningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="AddCylinder")
        {
            IncrementBoatVolume(1f);
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            IncrementBoatVolume(-1f);
        }
        if (other.tag == "Wall")
        {
            IncrementBoatVolume(-1f);

        }
    }


    public void IncrementBoatVolume(float value)
    {
        if(boats.Count == 0)
        {
            if (value>0)
            {
                CreateBoat(value);
            }
            else
            {
                //Gameover
            }
        } 
        else
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
}
