using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocks : MonoBehaviour
{
    public float boxSpeed = 1f;
    public float downMovement = 4f;
    Vector2 movement;

    public bool stopMoving;
    bool rightRaycast;
    bool leftRaycast;
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
            if (!rightRaycast)
            {
                if (Input.GetKeyDown(KeyCode.D))
                    transform.position = transform.position + new Vector3(boxSpeed, 0, 0);
            }
            
           
            




            if (!leftRaycast)
            {
                 if (Input.GetKeyDown(KeyCode.A))
                    transform.position = transform.position + new Vector3(-boxSpeed, 0, 0);
            }

           


           
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

                //Left Racast
                Vector2 left = (transform.TransformDirection(Vector2.left)) * raycastDistance;
                hit[0] = Physics2D.Raycast(transform.position + new Vector3(-1f, 0.55f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, .55f, 0), left, Color.green);

                hit[1] = Physics2D.Raycast(transform.position + new Vector3(-1f, 0, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), left, Color.red);

                hit[2] = Physics2D.Raycast(transform.position + new Vector3(-1f, -.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -.5f, 0), left, Color.blue);

                if (hit[0] == true || hit[1] == true || hit[2] == true)
                {
                    leftRaycast = true;
                   
                    //turn of Left movement
                }

                else if (hit[0] == false || hit[1] == false || hit[2] == false)
                {
                    leftRaycast = false;
                }





                    //Right Raycasts
                    hit[3] = Physics2D.Raycast(transform.position + new Vector3(2f, 0.55f, 0), Vector2.right, raycastDistance, groundLayer);
                Vector2 right = (transform.TransformDirection(Vector2.right)) * raycastDistance;
                Debug.DrawRay(transform.position + new Vector3(2f, .55f, 0), right, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(2f, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(2f, 0, 0), right, Color.red);

                hit[5] = Physics2D.Raycast(transform.position + new Vector3(2f, -.55f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(2f, -.55f, 0), right, Color.blue);

                if (hit[3] == true || hit[4] == true || hit[5] == true)
                {
                    rightRaycast = true;
                    
                    //turn of Left movement
                }

                else if (hit[3] == false || hit[4] == false || hit[5] == false)
                {
                    rightRaycast = false;
                }




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
                hit[0] = Physics2D.Raycast(transform.position + new Vector3(0, 2.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 2.5f, 0), left, Color.red);

                hit[1] = Physics2D.Raycast(transform.position + new Vector3(0, 2, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 2, 0), left, Color.red);

                hit[2] = Physics2D.Raycast(transform.position + new Vector3(0, 1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 1.5f, 0), left, Color.red);



                hit[3] = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 1, 0), left, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), Vector2.left, raycastDistance, groundLayer);
                
                Debug.DrawRay(transform.position + new Vector3(-1f, .5f, 0), left, Color.red);

                hit[5] = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), left, Color.red);


                //Second brick Raycasts
                hit[6] = Physics2D.Raycast(transform.position + new Vector3(0, -.5f, 0), Vector2.left, raycastDistance, groundLayer);
                
                Debug.DrawRay(transform.position + new Vector3(-1f, -.5f, 0), left, Color.red);
                //down
                hit[7] = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -1, 0), left, Color.red);
                //Middle
                hit[8] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -1.5f, 0), left, Color.red);

                if (hit[0] == true || hit[1] == true || hit[2] == true || hit[3] == true || hit[4] == true || hit[5] == true || hit[6] == true || hit[7] == true || hit[8] == true)
                {
                    leftRaycast = true;
                    
                    //turn of Left movement
                }

                else if (hit[0] == false || hit[1] == false || hit[2] == false || hit[3] == false || hit[4] == false || hit[5] == false || hit[6] == false || hit[7] == false || hit[8] == false)
                {
                    leftRaycast = false;
                }




                    //Right rays

                Vector2 right = (transform.TransformDirection(Vector2.up)) * raycastDistance;
                //up block raycasts
                hit[9] = Physics2D.Raycast(transform.position + new Vector3(0, 2.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 2.5f, 0), right, Color.red);

                hit[10] = Physics2D.Raycast(transform.position + new Vector3(0, 2, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 2, 0), right, Color.red);

                hit[11] = Physics2D.Raycast(transform.position + new Vector3(0, 1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 1.5f, 0), right, Color.red);



                hit[12] = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 1, 0), right, Color.red);

                hit[13] = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), Vector2.right, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(1f, .5f, 0), right, Color.red);

                hit[14] = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), right, Color.red);

                

                //Second brick Raycasts
                hit[15] = Physics2D.Raycast(transform.position + new Vector3(0, -.5f, 0), Vector2.right, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(1f, -.5f, 0), right, Color.red);
                //down
                hit[16] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -1.5f, 0), right, Color.red);
                //Middle
                hit[17] = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -1f, 0), right, Color.red);

                if (hit[9] == true || hit[10] == true || hit[11] == true || hit[12] == true || hit[13] == true || hit[14] == true || hit[15] == true || hit[16] == true || hit[17] == true)
                {
                    rightRaycast = true;
                    
                }

                else if (hit[9] == false || hit[10] == false || hit[11] == false || hit[12] == false || hit[13] == false || hit[14] == false || hit[15] == false || hit[16] == false || hit[17] == false)
                {
                    rightRaycast = false;
                }


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

                hit[1] = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), left, Color.red);

                hit[2] = Physics2D.Raycast(transform.position + new Vector3(1, -.4f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -.4f, 0), left, Color.blue);

                if (hit[0] == true || hit[1] == true || hit[2] == true)
                {
                    rightRaycast = true;

                    //turn of Left movement
                }

                else if (hit[0] == false || hit[1] == false || hit[2] == false)
                {
                    rightRaycast = false;
                }




               Vector2 right = (transform.TransformDirection(Vector2.right)) * raycastDistance;
                hit[3] = Physics2D.Raycast(transform.position + new Vector3(-2f, 0.4f, 0), Vector2.left, raycastDistance, groundLayer);
                
                Debug.DrawRay(transform.position + new Vector3(-2f, .4f, 0), right, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(-2f, 0, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-2f, 0, 0), right, Color.green);

                hit[5] = Physics2D.Raycast(transform.position + new Vector3(-2f, -.4f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-2f, -.4f, 0), right, Color.red);

                if (hit[3] == true || hit[4] == true || hit[5] == true)
                {
                    leftRaycast = true;

                    //turn of Left movement
                }

                else if (hit[3] == false || hit[4] == false || hit[5] == false)
                {
                    leftRaycast = false;
                }



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

                if (hit[0] == true || hit[1] == true || hit[2] == true || hit[3] == true || hit[4] == true || hit[5] == true || hit[6] == true || hit[7] == true || hit[8] == true)
                {
                    rightRaycast = true;

                    //turn of Left movement
                }

                else if (hit[0] == false || hit[1] == false || hit[2] == false || hit[3] == false || hit[4] == false || hit[5] == false || hit[6] == false || hit[7] == false || hit[8] == false)
                {
                    rightRaycast = false;
                }







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


                if (hit[9] == true || hit[10] == true || hit[11] == true || hit[12] == true || hit[13] == true || hit[14] == true || hit[15] == true || hit[16] == true || hit[17] == true)
                {
                    leftRaycast = true;

                }

                else if (hit[9] == false || hit[10] == false || hit[11] == false || hit[12] == false || hit[13] == false || hit[14] == false || hit[15] == false || hit[16] == false || hit[17] == false)
                {
                    leftRaycast = false;
                }





                if (hit[14] == true)
                {
                    Debug.Log("Touched2");
                }
            }

        }
    }
}
