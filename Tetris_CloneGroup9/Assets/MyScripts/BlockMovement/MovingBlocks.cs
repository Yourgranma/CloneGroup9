using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocks : MonoBehaviour
{
    public float boxSpeed = 0.04f;
    public float downMovement = 2f;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SideMovement();
        SpeedIncrease();

        RotatingBlock();
        //float horizontalInput = Input.GetAxis("Horizontal");
        //transform.position = transform.position + new Vector3(horizontalInput * boxSpeed, 0, 0);

    }

    private void SideMovement()
    {
        if (Input.GetKeyDown(KeyCode.D))
            transform.position = transform.position + new Vector3(boxSpeed, 0, 0);

        else if(Input.GetKeyDown(KeyCode.A))
            transform.position = transform.position + new Vector3(-boxSpeed, 0, 0);
    }
    private void SpeedIncrease()
    {
        if (Input.GetKey(KeyCode.S))
            transform.position = transform.position + new Vector3(0, -boxSpeed, 0);

        else
            transform.position = transform.position + new Vector3(0, -downMovement * Time.deltaTime, 0);
    }
    private void RotatingBlock()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
