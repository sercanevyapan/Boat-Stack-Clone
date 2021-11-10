using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidingBoat : MonoBehaviour
{


    private float _value;

    public void IncerementBoatVolume(float value)
    {
        _value += value;
        if (_value>1)
        {
            float leftValue = _value - 1;
            int boatCount = PlayerController.Current.boats.Count;
            transform.localPosition = new Vector3(transform.localPosition.x,                      -0.5f*(boatCount-1)+ -0.25f ,transform.localPosition.z);
            transform.localScale = new Vector3(0.5f,transform.localScale.y,1f);
            PlayerController.Current.CreateBoat(leftValue);


        }else if (_value < 0)
        {
          
            PlayerController.Current.DestroyBoats(this);

     
        }
        else
        {
            int boatCount = PlayerController.Current.boats.Count;
            transform.localPosition = new Vector3(transform.localPosition.x, -0.5f * (boatCount - 1) + -0.25f*_value, transform.localPosition.z);
            transform.localScale = new Vector3(0.5f *_value, transform.localScale.y, _value);
        }
    }
}
