using UnityEngine;

public class grappleScript : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    [SerializeField] private LayerMask grappleLayer;
    public int grappleLength;
    public float grappleSpeed;
    private DistanceJoint2D joint;
    private Vector3 grapplePoint;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joint=gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Left mouse button was clicked
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -50;//Camera.main.nearClipPlane; // Set z to near clip plane
            Vector3 worldPosition = m_Camera.ScreenToWorldPoint(mousePosition);
            worldPosition.z = -50;
            Debug.Log(worldPosition);
            float dist = Vector2.Distance(transform.position, worldPosition);
            Debug.Log(dist);
            RaycastHit2D hit = Physics2D.Raycast(
                worldPosition, 
                Vector2.zero,
                Mathf.Infinity,
                grappleLayer

                );
            if (hit.collider != null)
            {
                grapplePoint = hit.point;
                grapplePoint.z = 0;
                /*if (transform.position != grapplePoint)
                {
                    rb.MovePosition(grapplePoint);
                }
                else*/
                ///{

                    
                    joint.connectedAnchor = grapplePoint;
                    joint.enabled = true;
                    joint.distance = grappleLength;
                //
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;


        }
    }
    
}
