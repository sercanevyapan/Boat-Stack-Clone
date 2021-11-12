using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    private Vector3 _target = Vector3.zero;

    public float[] cameraVector3Position;

    void Update()
    {
       
        _target = new Vector3(player.position.x+cameraVector3Position[0], player.position.y+ cameraVector3Position[1], player.position.z- cameraVector3Position[2]);
        transform.position = Vector3.Lerp(transform.position, _target, 1f);
    }
}
