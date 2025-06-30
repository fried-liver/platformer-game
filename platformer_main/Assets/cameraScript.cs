using System;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public GameObject player;
     // The object the camera follows
    public float smoothSpeed;
    
    public Vector3 offset;
    private Transform target;
    private playerScript player_script;
    private void Start()
    {
        target = player.transform;
        player_script=player.GetComponent<playerScript>();
    }
    void FixedUpdate()
    {
        if (target == null) return;
        if (player_script.isRight)
        {

            //offset.x = Mathf.Lerp(offset.x, Math.Abs(offset.x), smoothSpeed);
            offset.x = Math.Abs(offset.x);
        }
        else
        {
            //offset.x = Mathf.Lerp(offset.x, -Math.Abs(offset.x), smoothSpeed);
            offset.x = -Math.Abs(offset.x);
        }
        //Vector3 desiredPosition = target.position + offset;
        Vector3 desiredPosition = new Vector3 (target.position.x + offset.x, target.position.y+offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;
        //rb.linearVelocity=new Vector2 ((target.position.x-transform.position.x)*smoothSpeed, (target.position.y - transform.position.y)*smoothSpeed);
        transform.position = smoothedPosition;
        //Optional: Make the camera look at the target
        //transform.LookAt(target);
    }
    
    
}
