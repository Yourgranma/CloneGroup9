using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastingBricks : MonoBehaviour
{
    public float raycastDistance = 5f;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RayCastTests()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);
    }
}
