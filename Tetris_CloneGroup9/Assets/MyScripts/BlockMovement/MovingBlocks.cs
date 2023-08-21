using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocks : MonoBehaviour
{
    public float boxSpeed = 1f;
    public float downMovement = 4f;
    Vector2 movement;

    public bool stopMoving;

    private Rigidbody2D rigidbody2D;
    
    private TetrisManager tetrisManager;
    private GameObject gameManager;

    public bool buttonsOff;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        tetrisManager = gameManager.GetComponent<TetrisManager>();
        stopMoving = false;
        buttonsOff = false;
    }

    // Update is called once per frame
    void Update()
    {
        SideMovement();
        SpeedIncrease();

        RotatingBlock();

        for (int i = 0; i <= 3; i++)
        {
            if (GetComponentInChildren<RayCastingBricks>().hit[i] == true)
            {
                boxSpeed = 0f;
                downMovement = 0f;
                tetrisManager.blockSpawning.spawning = true;
                stopMoving = true;
                //rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                GetComponent<MovingBlocks>().enabled = false;
                
               
            }

        }
        //float horizontalInput = Input.GetAxis("Horizontal");
        //transform.position = transform.position + new Vector3(horizontalInput * boxSpeed, 0, 0);

    }

    private void SideMovement()
    {
        if (!buttonsOff)
        {
            if (Input.GetKeyDown(KeyCode.D))
                transform.position = transform.position + new Vector3(boxSpeed, 0, 0);

            else if (Input.GetKeyDown(KeyCode.A))
                transform.position = transform.position + new Vector3(-boxSpeed, 0, 0);
        }
        
    }
    private void SpeedIncrease()
    {
        if (!stopMoving)
        {
            if (Input.GetKey(KeyCode.S))
                transform.position = transform.position + new Vector3(0, -boxSpeed, 0);

            else
                transform.position = transform.position + new Vector3(0, -downMovement * Time.deltaTime, 0);
        }
        
    }
    private void RotatingBlock()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(0, 0, 90);
        }
    }

    

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Brick"))
        {
            buttonsOff = true;
        }
    }

    private void StopingObject()
    {
        if (GetComponentInChildren<RayCastingBricks>().typeOfTetro == RayCastingBricks.TypeOfTetro.Straight)
        {

        }
    }
}
