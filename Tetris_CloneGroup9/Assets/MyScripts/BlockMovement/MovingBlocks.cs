using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocks : MonoBehaviour
{
    public float boxSpeed = 1f;
    public float downMovement = 4f;
    Vector2 movement;

    public bool stopMoving;

    private TetrisManager tetrisManager;
    private GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    // Start is called before the first frame update
    void Start()
    {
        tetrisManager = gameManager.GetComponent<TetrisManager>();
        stopMoving = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag=="Brick")
        {
            boxSpeed = 0f;
            downMovement = 0f;
            tetrisManager.blockSpawning.spawning = true;
            stopMoving = true;
            GetComponent<MovingBlocks>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
