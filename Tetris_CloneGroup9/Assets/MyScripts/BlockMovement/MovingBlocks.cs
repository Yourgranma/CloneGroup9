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

    public LayerMask groundLayer;
    public RaycastHit2D[] hit = new RaycastHit2D[19];
    public float raycastDistance = 1f;
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
        StopingObject();
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
            if (GetComponentInChildren<RayCastingBricks>().rotations == RayCastingBricks.Rotations.Zero)
            {
                /*hit[0] = Physics2D.Raycast(transform.position + new Vector3(-1f, 0.4f, 0), Vector2.left, raycastDistance, groundLayer);
                Vector2 left = (transform.TransformDirection(Vector2.left)) * raycastDistance;
                Debug.DrawRay(transform.position + new Vector3(-1f, .4f, 0), left, Color.red);

                hit[1] = Physics2D.Raycast(transform.position + new Vector3(-1f, 0, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), left, Color.red);

                hit[2] = Physics2D.Raycast(transform.position + new Vector3(-1f, -.4f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -.4f, 0), left, Color.red);

              

                hit[3] = Physics2D.Raycast(transform.position + new Vector3(2f, 0.4f, 0), Vector2.right, raycastDistance, groundLayer);
                Vector2 right = (transform.TransformDirection(Vector2.right)) * raycastDistance;
                Debug.DrawRay(transform.position + new Vector3(2f, .4f, 0), right, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(2f, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(2f, 0, 0), right, Color.red);

                hit[5] = Physics2D.Raycast(transform.position + new Vector3(2f, -.4f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(2f, -.4f, 0), right, Color.red);*/
            }

            if(GetComponentInChildren<RayCastingBricks>().rotations == RayCastingBricks.Rotations.Ninety)
            {
                if (hit[0])
                {
                    /*for (int i = 0; i <= 8; i++)
                {
                    float yOffset = 0.5f + (i * 0.5f); // Calculate vertical offset
                    Vector2 raycastDirection = transform.TransformDirection(Vector2.down);
                    if (i <=5 && i>=0)
                    {
                        hit[i] = Physics2D.Raycast(transform.position + new Vector3(-1f, -yOffset, 0), Vector2.left, raycastDistance, groundLayer);
                        Debug.DrawRay(transform.position + new Vector3(-1f, -yOffset, 0), raycastDirection * raycastDistance, Color.red);
                    }

                    if (i>5)
                    {
                        hit[i] = Physics2D.Raycast(transform.position + new Vector3(-1f, yOffset, 0), Vector2.left, raycastDistance, groundLayer);
                        Debug.DrawRay(transform.position + new Vector3(-1f, yOffset, 0), raycastDirection * raycastDistance, Color.red);
                    }
                     

                }*/
                    /*for(int i = 0; i <= 8; i++)
                    {
                        float k = 0.5f;
                        for(float j=-1; j <= 2.5; k++)
                        {
                            Vector2 letf = (transform.TransformDirection(Vector2.down)) * raycastDistance;
                            hit[i] = Physics2D.Raycast(transform.position + new Vector3(-1f, k, 0), Vector2.down, raycastDistance, groundLayer);
                            Debug.DrawRay(transform.position + new Vector3(-1f, k, 0), letf, Color.red);
                        }

                    }*/
                }


                Vector2 left = (transform.TransformDirection(Vector2.down)) * raycastDistance;
                //up block raycasts
                hit[0] = Physics2D.Raycast(transform.position + new Vector3(-1f, 2.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 2.5f, 0), left, Color.red);

                hit[1] = Physics2D.Raycast(transform.position + new Vector3(-1f, 2, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 2, 0), left, Color.red);

                hit[2] = Physics2D.Raycast(transform.position + new Vector3(-1f, 1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 1.5f, 0), left, Color.red);



                hit[3] = Physics2D.Raycast(transform.position + new Vector3(-1f, 1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 1, 0), left, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(-1f, 0.5f, 0), Vector2.left, raycastDistance, groundLayer);
                
                Debug.DrawRay(transform.position + new Vector3(-1f, .5f, 0), left, Color.red);

                hit[5] = Physics2D.Raycast(transform.position + new Vector3(-1f, 0, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), left, Color.red);


                //Second brick Raycasts
                hit[6] = Physics2D.Raycast(transform.position + new Vector3(-1f, -.5f, 0), Vector2.left, raycastDistance, groundLayer);
                
                Debug.DrawRay(transform.position + new Vector3(-1f, -.5f, 0), left, Color.red);
                //down
                hit[7] = Physics2D.Raycast(transform.position + new Vector3(-1f, -1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -1, 0), left, Color.red);
                //Middle
                hit[8] = Physics2D.Raycast(transform.position + new Vector3(-1f, -1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -1.5f, 0), left, Color.red);


                //Right rays

                Vector2 right = (transform.TransformDirection(Vector2.up)) * raycastDistance;
                //up block raycasts
                hit[9] = Physics2D.Raycast(transform.position + new Vector3(1f, 2.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 2.5f, 0), right, Color.red);

                hit[10] = Physics2D.Raycast(transform.position + new Vector3(1f, 2, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 2, 0), right, Color.red);

                hit[11] = Physics2D.Raycast(transform.position + new Vector3(1f, 1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 1.5f, 0), right, Color.red);



                hit[12] = Physics2D.Raycast(transform.position + new Vector3(1f, 1, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 1, 0), right, Color.red);

                hit[13] = Physics2D.Raycast(transform.position + new Vector3(1f, 0.5f, 0), Vector2.right, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(1f, .5f, 0), right, Color.red);

                hit[14] = Physics2D.Raycast(transform.position + new Vector3(1f, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), right, Color.red);

                

                //Second brick Raycasts
                hit[15] = Physics2D.Raycast(transform.position + new Vector3(1f, -.5f, 0), Vector2.right, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(1f, -.5f, 0), right, Color.red);
                //down
                hit[16] = Physics2D.Raycast(transform.position + new Vector3(1f, -1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -1.5f, 0), right, Color.red);
                //Middle
                hit[17] = Physics2D.Raycast(transform.position + new Vector3(1f, -1f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -1f, 0), right, Color.red);
                if (hit[17] == true)
                {
                    Debug.Log("Touched");
                }
            }

            else if (GetComponentInChildren<RayCastingBricks>().rotations == RayCastingBricks.Rotations.OneEighty)
            {
                Vector2 left = (transform.TransformDirection(Vector2.left)) * raycastDistance;
                hit[0] = Physics2D.Raycast(transform.position + new Vector3(1f, 0.4f, 0), Vector2.right, raycastDistance, groundLayer);
                
                Debug.DrawRay(transform.position + new Vector3(1f, .4f, 0), left, Color.red);

                hit[1] = Physics2D.Raycast(transform.position + new Vector3(1f, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), left, Color.red);

                hit[2] = Physics2D.Raycast(transform.position + new Vector3(1f, -.4f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -.4f, 0), left, Color.red);



                hit[3] = Physics2D.Raycast(transform.position + new Vector3(-2f, 0.4f, 0), Vector2.left, raycastDistance, groundLayer);
                Vector2 right = (transform.TransformDirection(Vector2.right)) * raycastDistance;
                Debug.DrawRay(transform.position + new Vector3(-2f, .4f, 0), right, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(2f, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-2f, 0, 0), right, Color.red);

                hit[5] = Physics2D.Raycast(transform.position + new Vector3(2f, -.4f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-2f, -.4f, 0), right, Color.red);

                if (hit[3] == true)
                {
                    Debug.Log("Touched1");
                }
            }

            else if (GetComponentInChildren<RayCastingBricks>().rotations == RayCastingBricks.Rotations.MinusNinety)
            {
                Vector2 left = (transform.TransformDirection(Vector2.up)) * raycastDistance;
                //up block raycasts
                hit[0] = Physics2D.Raycast(transform.position + new Vector3(0, -2.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0f, -2.5f, 0), left, Color.red);

                hit[1] = Physics2D.Raycast(transform.position + new Vector3(0, -2, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0f, -2, 0), left, Color.red);

                hit[2] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0f, -1.5f, 0), left, Color.red);



                hit[3] = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0f, -1f, 0), left, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(0, -.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0f, -.5f, 0), left, Color.red);

                hit[5] = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0f, 0f, 0), left, Color.red);



                hit[6] = Physics2D.Raycast(transform.position + new Vector3(0, .5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0f, .5f, 0), left, Color.red);

                hit[7] = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0f, 1, 0), left, Color.red);

                hit[8] = Physics2D.Raycast(transform.position + new Vector3(0, 1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0f, 1.5f, 0), left, Color.red);









                //other

                Vector2 right = (transform.TransformDirection(Vector2.down)) * raycastDistance;
                //up block raycasts
                hit[9] = Physics2D.Raycast(transform.position + new Vector3(0, -2.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -2.5f, 0), right, Color.red);

                hit[10] = Physics2D.Raycast(transform.position + new Vector3(0, -2, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -2, 0), right, Color.red);

                hit[11] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -1.5f, 0), right, Color.red);



                hit[12] = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -1, 0), right, Color.red);

                hit[13] = Physics2D.Raycast(transform.position + new Vector3(0, - 0.5f, 0), Vector2.left, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(0f, -.5f, 0), right, Color.red);

                hit[14] = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, 0, 0), right, Color.blue);



                //Second brick Raycasts
                hit[15] = Physics2D.Raycast(transform.position + new Vector3(0, .5f, 0), Vector2.left, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(0, .5f, 0), right, Color.red);
                //down
                hit[16] = Physics2D.Raycast(transform.position + new Vector3(0, 1f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, 1f, 0), right, Color.red);
                //Middle
                hit[17] = Physics2D.Raycast(transform.position + new Vector3(0, 1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), right, Color.red);






                if (hit[14] == true)
                {
                    Debug.Log("Touched2");
                }
            }

        }
    }
}
