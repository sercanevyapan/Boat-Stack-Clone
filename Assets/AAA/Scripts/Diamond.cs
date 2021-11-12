using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RidingBoat")
        {

            Destroy(this.gameObject);

            GameManager.instance.AddPoint(1);

        }
    }
}
