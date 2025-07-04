using UnityEngine;

public class backgroundScript : MonoBehaviour
{
    public GameObject cam;
    public float speed;
    
    private Rigidbody2D rb;
    private Rigidbody2D rb_p;
    private cameraScript camera_;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb_p=cam.GetComponent<Rigidbody2D>();
        camera_=cam.GetComponent<cameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(rb_p.linearVelocity);
        rb.linearVelocity= camera_.velocity_ * speed;
        
        //Debug.Log(camera_.velocity_);    
    }
}
