using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject feet;
    public int speed;
    public int jump;
    private bool grounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        //rb.freezeRotation = true;
    }


    // Update is called once per frame
    void Update()
    {

        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y);
        //rb.linearVelocityX = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
            grounded = false;
        }

        

}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider)
        {
            Vector3 normal = collision.GetContact(0).normal;
            if (normal == Vector3.up)
            {
                grounded = true;
            }

        }
            
    }

}
