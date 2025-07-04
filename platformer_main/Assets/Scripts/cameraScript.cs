using System;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class cameraScript : MonoBehaviour
{

    public GameObject player;
     // The object the camera follows
    public float smoothSpeed;
    public Vector2 velocity_;
    public Vector3 offset;
    private Transform target;
    private playerScript player_script;
    private Rigidbody2D rb;
    private Vector3 pos;
    private Vector3 desiredPosition;
    private Vector3 smoothedPosition;
    
    private void Start()
    {
        target = player.transform;
        player_script=player.GetComponent<playerScript>();
        rb=GetComponent<Rigidbody2D>();
        pos = transform.position;
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
        desiredPosition = new Vector3 (target.position.x + offset.x, target.position.y+offset.y, transform.position.z);
        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        //rb.linearVelocity=new Vector2 ((target.position.x-transform.position.x)*smoothSpeed, (target.position.y - transform.position.y)*smoothSpeed);
        //transform.position = smoothedPosition;
        rb.MovePosition(smoothedPosition);
        //Optional: Make the camera look at the target
        //transform.LookAt(target);
        rb.linearVelocity = smoothedPosition;
        velocity_ = (transform.position - pos) / Time.deltaTime;
        pos = transform.position;
        Debug.Log(velocity_);
    }
    
    
}
