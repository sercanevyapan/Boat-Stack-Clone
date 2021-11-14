using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public float countDown = 2.0f;
    public float speed=2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown > 0)
            transform.position += Vector3.right * Time.deltaTime * speed;
        else if (countDown > -2.0f)
            transform.position += Vector3.left * Time.deltaTime * speed;
        else if (countDown < -2.0f)
            countDown = 2.0f;
    }
}
