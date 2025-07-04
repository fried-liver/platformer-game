using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class playerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public int friction;
    public int speed;
    public int jump;
    public Vector2 boxSize;
    public float castDistance;
    public Vector2 boxSizeSide;
    public float castDistanceSide;
    public LayerMask groundLayer;
    

    private bool grounded;
    private bool wallLeft;
    private bool wallRight;
    public bool isRight;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        
    }


    // Update is called once per frame
    void Update()
    {
        grounded=IsGrounded();
        wallLeft=IsTouchingWallLeft();
        wallRight=IsTouchingWallRight();

        if (Input.GetAxis("Horizontal") < 0)
        {
            isRight = false;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            isRight = true;
        }
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y);

                //Debug.Log(grounded);
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
            }
            else if (wallLeft || wallRight) 
            {
                //rb.linearVelocity = new Vector2(-20, rb.linearVelocity.y);
                wallLeft = false;
                wallRight = false;
            }
        } 
        if (grounded==false && (wallLeft || wallRight) && rb.linearVelocity.y<0)
        {
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y*0.95f);
            
        }


        if (rb.linearVelocity.magnitude > 0 && grounded)
        {
            rb.AddForce(-rb.linearVelocity.normalized * friction);
        }



    }

    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer)){
            
            return true;
        }

        return false;
        
    }


    public bool IsTouchingWallLeft()
    {
        if (Physics2D.BoxCast(transform.position, boxSizeSide, 0, -transform.right, castDistanceSide, groundLayer))
        {
           
            return true;
        }
        return false;
        
    }
    public bool IsTouchingWallRight()
    {
        if (Physics2D.BoxCast(transform.position, boxSizeSide, 0, transform.right, castDistanceSide, groundLayer))
        {
            
            return true;
        }
        return false;

    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up*castDistance, boxSize);
        Gizmos.DrawWireCube(transform.position - transform.right * castDistanceSide, boxSizeSide);
        Gizmos.DrawWireCube(transform.position +transform.right * castDistanceSide, boxSizeSide);
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider)
        {
            Vector3 normal = collision.GetContact(0).normal;
            Debug.Log(normal);
            if (normal == Vector3.up)
            {
                grounded = true;
            }

        }
            
    }*/

}
