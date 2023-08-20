using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastingBricks : MonoBehaviour
{
    public float raycastDistance = .5f;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayCastTests();
    }

    private void RayCastTests()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(1f,0,0), Vector2.down, raycastDistance, groundLayer);
        Vector2 down = (transform.TransformDirection(Vector2.down) )* raycastDistance;
        Vector2 left = transform.TransformDirection(Vector2.left) * raycastDistance;
        Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), down, Color.blue);
        Debug.DrawRay(transform.position, left, Color.blue);
        /*if (hit.collider.IsTouchingLayers(groundLayer))
        {
            if(Vector2.Distance(transform.position, hit.transform.position) < 1f)
            {
                //Stop the object
            }
        }*/



    }
    void RaycastSquare()
    {

    }

    void RaycastT()
    {

    }
}
