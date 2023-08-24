using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocks : MonoBehaviour
{
    public float boxSpeed = 1f;
    public float downMovement = 4f;
    Vector2 movement;

    public bool stopMoving;
    public bool rightRaycast;
    public bool leftRaycast;
    bool stopRotation;
    Rigidbody2D rigidbody2D;
    
    private TetrisManager tetrisManager;
    private GameObject gameManager;

    public bool buttonsOff;

    public LayerMask groundLayer;

    public LayerMask wallsMask;
    public RaycastHit2D[] hit = new RaycastHit2D[19];
    public float raycastDistance = 1f;
    public float wallDistance = 2.5f;



    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    // Start is called before the first frame update
    void Start()
    {
        stopRotation = false;
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
                Destroy(gameObject, 1);
                
               
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
        if (Input.GetKeyDown(KeyCode.W) && stopRotation==false)
        {
            if(GetComponentInChildren<RayCastingBricks>().typeOfTetro != RayCastingBricks.TypeOfTetro.Square)
            {
                transform.Rotate(0, 0, 90);
            }
            
            
        }

        if (transform.rotation.eulerAngles.z ==180 && GetComponentInChildren<RayCastingBricks>().typeOfTetro == RayCastingBricks.TypeOfTetro.Straight)
        {
            transform.localEulerAngles =new Vector3(0,0, 0);
        }

        if (transform.rotation.eulerAngles.z == 180 && GetComponentInChildren<RayCastingBricks>().typeOfTetro == RayCastingBricks.TypeOfTetro.Skwe)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
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
       


        if(GetComponentInChildren<RayCastingBricks>().typeOfTetro == RayCastingBricks.TypeOfTetro.Square)
        {
            Vector2 left = (transform.TransformDirection(Vector2.left));

            hit[0] = Physics2D.Raycast(transform.position + new Vector3(0f, 1.5f, 0), Vector2.left, raycastDistance, groundLayer);
            Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), left, Color.green);

            hit[1] = Physics2D.Raycast(transform.position + new Vector3(0f, 1f, 0), Vector2.left, raycastDistance, groundLayer);
            Debug.DrawRay(transform.position + new Vector3(0, 1f, 0), left, Color.green);

            hit[2] = Physics2D.Raycast(transform.position + new Vector3(0f, 0.5f, 0), Vector2.left, raycastDistance, groundLayer);
            Debug.DrawRay(transform.position + new Vector3(0, .5f, 0), left, Color.green);

            hit[3] = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.left, raycastDistance, groundLayer);
            Debug.DrawRay(transform.position + new Vector3(0, 0, 0), left, Color.red);

            hit[4] = Physics2D.Raycast(transform.position + new Vector3(0, -.5f, 0), Vector2.left, raycastDistance, groundLayer);
            Debug.DrawRay(transform.position + new Vector3(0, -.5f, 0), left, Color.blue);



            if (hit[0] == true || hit[1] == true || hit[2] == true || hit[3] == true || hit[4] == true)
            {
                leftRaycast = true;

            }

            else if (hit[0] == false || hit[1] == false || hit[2] == false || hit[3] == false || hit[4] == false)
            {
                leftRaycast = false;
            }


            Debug.Log("Im working");
            //For the right side
            Vector2 right = (transform.TransformDirection(Vector2.right));

            hit[5] = Physics2D.Raycast(transform.position + new Vector3(1f, 1.5f, 0), Vector2.right, raycastDistance, groundLayer);
            Debug.DrawRay(transform.position + new Vector3(1, 1.5f, 0), right, Color.green);

            hit[6] = Physics2D.Raycast(transform.position + new Vector3(1f, 1f, 0), Vector2.right, raycastDistance, groundLayer);
            Debug.DrawRay(transform.position + new Vector3(1, 1f, 0), right, Color.green);

            hit[7] = Physics2D.Raycast(transform.position + new Vector3(1f, 0.5f, 0), Vector2.right, raycastDistance, groundLayer);
            Debug.DrawRay(transform.position + new Vector3(1, .5f, 0), right, Color.green);

            hit[8] = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), Vector2.right, raycastDistance, groundLayer);
            Debug.DrawRay(transform.position + new Vector3(1, 0, 0), right, Color.red);

            hit[9] = Physics2D.Raycast(transform.position + new Vector3(1, -.5f, 0), Vector2.right, raycastDistance, groundLayer);
            Debug.DrawRay(transform.position + new Vector3(1, -.5f, 0), right, Color.blue);

            if (hit[5] == true || hit[6] == true || hit[7] == true || hit[8] == true || hit[9] == true)
            {
                rightRaycast = true;

            }

            else if (hit[5] == false || hit[6] == false || hit[7] == false || hit[8] == false || hit[9] == false)
            {
                rightRaycast = false;
            }

        }
        StraightT();
        T_Shaped();
        _LShape();
        _SkweShape();

    }

    private void StraightT()
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

            if (GetComponentInChildren<RayCastingBricks>().rotations == RayCastingBricks.Rotations.Ninety)
            {

                StoppingStraightRotation();

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
                Debug.DrawRay(transform.position + new Vector3(1f, 1, 0), right, Color.blue);

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



                //to stop rotation
                

                

                



                if (hit[9] == true || hit[10] == true || hit[11] == true || hit[12] == true || hit[13] == true || hit[14] == true || hit[15] == true || hit[16] == true || hit[17] == true)
                {
                    rightRaycast = true;

                }

                else if (hit[9] == false || hit[10] == false || hit[11] == false || hit[12] == false || hit[13] == false || hit[14] == false || hit[15] == false || hit[16] == false || hit[17] == false)
                {
                    rightRaycast = false;
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

                hit[13] = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f, 0), Vector2.left, raycastDistance, groundLayer);

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

            }

        }
    }
    private void _LShape()
    {
        if (GetComponentInChildren<RayCastingBricks>().typeOfTetro == RayCastingBricks.TypeOfTetro.L)
        {
            if (GetComponentInChildren<RayCastingBricks>().rotations == RayCastingBricks.Rotations.Zero)
            {

                //Left Racast
                Vector2 left = (transform.TransformDirection(Vector2.left)) * raycastDistance;
                hit[0] = Physics2D.Raycast(transform.position + new Vector3(1, 1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1, 1.5f, 0), left, Color.red);

                hit[1] = Physics2D.Raycast(transform.position + new Vector3(1, 1f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1, 1, 0), left, Color.blue);      
                
                hit[2] = Physics2D.Raycast(transform.position + new Vector3(-1f, 0.55f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, .55f, 0), left, Color.green);

                hit[3] = Physics2D.Raycast(transform.position + new Vector3(-1f, 0, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), left, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(-1f, -.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -.5f, 0), left, Color.blue);


                if (hit[0] == true || hit[1] == true || hit[2] == true || hit[3] == true || hit[4] == true)
                {
                    leftRaycast = true;

                    //turn of Left movement
                }

                else if (hit[0] == false || hit[1] == false || hit[2] == false || hit[3] == false || hit[4] == false)
                {
                    leftRaycast = false;
                }





                //Right Raycasts
                Vector2 right = (transform.TransformDirection(Vector2.right)) * raycastDistance;
                

                hit[5] = Physics2D.Raycast(transform.position + new Vector3(0f, 1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 1.5f, 0), right, Color.red);

                hit[6] = Physics2D.Raycast(transform.position + new Vector3(0.5f, 1f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 1f, 0), right, Color.blue);


                hit[7] = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0.5f, 0), Vector2.right, raycastDistance, groundLayer);
                
                Debug.DrawRay(transform.position + new Vector3(1f, .5f, 0), right, Color.blue);

                hit[8] = Physics2D.Raycast(transform.position + new Vector3(0f, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), right, Color.red);

                hit[9] = Physics2D.Raycast(transform.position + new Vector3(0.5f, -.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -.5f, 0), right, Color.magenta);

                
                

                if (hit[5] == true || hit[6] == true || hit[7] == true || hit[8] == true || hit[9] == true )
                {
                    rightRaycast = true;

                    //turn of Left movement
                }

                else if (hit[5] == false || hit[6] == false || hit[7] == false || hit[8] == false || hit[9] == false )
                {
                    rightRaycast = false;
                }




            }

            if (GetComponentInChildren<RayCastingBricks>().rotations == RayCastingBricks.Rotations.Ninety)
            {
                


                Vector2 left = (transform.TransformDirection(Vector2.down)) * raycastDistance;
                //up block raycasts
               

                hit[0] = Physics2D.Raycast(transform.position + new Vector3(-1, 1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-2f, 1.5f, 0), left, Color.red);



                hit[1] = Physics2D.Raycast(transform.position + new Vector3(-1, 1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-2f, 1, 0), left, Color.red);

                hit[2] = Physics2D.Raycast(transform.position + new Vector3(-1, 0.5f, 0), Vector2.left, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(-2f, .5f, 0), left, Color.red);

                hit[3] = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), left, Color.red);


                //Second brick Raycasts
                hit[4] = Physics2D.Raycast(transform.position + new Vector3(0, -.5f, 0), Vector2.left, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(-1f, -.5f, 0), left, Color.red);
                //down
                hit[5] = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -1, 0), left, Color.red);
                //Middle
                hit[6] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.left, raycastDistance, groundLayer);
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
                

                hit[14] = Physics2D.Raycast(transform.position + new Vector3(0, 1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 1.5f, 0), right, Color.red);



                hit[15] = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 1, 0), right, Color.red);

                hit[9] = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), Vector2.right, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(1f, .5f, 0), right, Color.red);

                hit[10] = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), right, Color.red);



                //Second brick Raycasts
                hit[11] = Physics2D.Raycast(transform.position + new Vector3(0, -.5f, 0), Vector2.right, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(1f, -.5f, 0), right, Color.red);
                //down
                hit[12] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -1.5f, 0), right, Color.red);
                //Middle
                hit[13] = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -1f, 0), right, Color.red);

                if (hit[14] == true || hit[15] == true || hit[9] == true || hit[10] == true || hit[11] == true || hit[12] == true || hit[13] == true )
                {
                    rightRaycast = true;

                }

                else if (hit[14] == false || hit[15] == false || hit[9] == false || hit[10] == false || hit[11] == false || hit[12] == false || hit[13] == false )
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

                hit[3] = Physics2D.Raycast(transform.position + new Vector3(-1, -1, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1, -1, 0), left, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(-1, -1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1, -1.5f, 0), left, Color.blue);


                if (hit[0] == true || hit[1] == true || hit[2] == true || hit[3] == true || hit[4] == true)
                {
                    rightRaycast = true;

                    //turn of Left movement
                }

                else if (hit[0] == false || hit[1] == false || hit[2] == false || hit[3] == false || hit[4] == false)
                {
                    rightRaycast = false;
                }




                Vector2 right = (transform.TransformDirection(Vector2.right)) * raycastDistance;


                hit[5] = Physics2D.Raycast(transform.position + new Vector3(-.5f, 0.4f, 0), Vector2.left, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(-1f, .4f, 0), right, Color.red);

                hit[6] = Physics2D.Raycast(transform.position + new Vector3(-.5f, 0, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), right, Color.green);

                hit[7] = Physics2D.Raycast(transform.position + new Vector3(-.5f, -.4f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -.4f, 0), right, Color.red);


                hit[8] = Physics2D.Raycast(transform.position + new Vector3(-.5f, -1.5f, 0), Vector2.left, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(-1f, -1.5f, 0), right, Color.red);

                hit[9] = Physics2D.Raycast(transform.position + new Vector3(-.5f, -1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -1, 0), right, Color.green);

                if ( hit[5] == true || hit[6] == true || hit[7] == true  || hit[8] == true || hit[9] == true )
                {
                    leftRaycast = true;

                    //turn of Left movement
                }

                else if ( hit[5] == false || hit[6] == false || hit[7] == false || hit[8] == false || hit[9] == false)
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
                

                hit[2] = Physics2D.Raycast(transform.position + new Vector3(1, -1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -1.5f, 0), left, Color.red);



                hit[3] = Physics2D.Raycast(transform.position + new Vector3(1, -1f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -1f, 0), left, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(1, -.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -.5f, 0), left, Color.red);

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
                
                hit[11] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -1.5f, 0), right, Color.red);



                hit[12] = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -1, 0), right, Color.red);

                hit[13] = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f, 0), Vector2.left, raycastDistance, groundLayer);

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

            }

        }
    }

    private void _SkweShape()
    {
        if (GetComponentInChildren<RayCastingBricks>().typeOfTetro == RayCastingBricks.TypeOfTetro.Skwe)
        {
            if (GetComponentInChildren<RayCastingBricks>().rotations == RayCastingBricks.Rotations.Zero)
            {

                //Left Racast
                Vector2 left = (transform.TransformDirection(Vector2.left)) * raycastDistance;
                hit[0] = Physics2D.Raycast(transform.position + new Vector3(-1f, 0.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, .5f, 0), left, Color.green);

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
                Vector2 right = (transform.TransformDirection(Vector2.right)) * raycastDistance;


                hit[3] = Physics2D.Raycast(transform.position + new Vector3(0f, 1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 1.5f, 0), right, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(0.5f, 1f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 1f, 0), right, Color.blue);


                hit[5] = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0.5f, 0), Vector2.right, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(1f, .5f, 0), right, Color.blue);

                hit[6] = Physics2D.Raycast(transform.position + new Vector3(0f, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0f, 0, 0), right, Color.red);

                hit[7] = Physics2D.Raycast(transform.position + new Vector3(0f, -.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0f, -.5f, 0), right, Color.magenta);




                if (hit[3] == true || hit[4] == true || hit[5] == true || hit[6] == true || hit[7] == true)
                {
                    rightRaycast = true;

                    //turn of Left movement
                }

                else if (hit[3] == false || hit[4] == false || hit[5] == false || hit[6] == false || hit[7] == false)
                {
                    rightRaycast = false;
                }




            }

            if (GetComponentInChildren<RayCastingBricks>().rotations == RayCastingBricks.Rotations.Ninety)
            {



                Vector2 left = (transform.TransformDirection(Vector2.down)) * raycastDistance;
                //up block raycasts


                hit[0] = Physics2D.Raycast(transform.position + new Vector3(-1, 1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-2f, 1.5f, 0), left, Color.red);



                hit[1] = Physics2D.Raycast(transform.position + new Vector3(-1, 1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-2f, 1, 0), left, Color.red);

                hit[2] = Physics2D.Raycast(transform.position + new Vector3(-1, 0.5f, 0), Vector2.left, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(-2f, .5f, 0), left, Color.red);

                hit[3] = Physics2D.Raycast(transform.position + new Vector3(-1, 0, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-2f, 0, 0), left, Color.red);


                //Second brick Raycasts
                hit[4] = Physics2D.Raycast(transform.position + new Vector3(-1, -.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-2f, -.5f, 0), left, Color.blue);
                //down
                hit[5] = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -1, 0), left, Color.red);
                //Middle
                hit[6] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.left, raycastDistance, groundLayer);
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


                hit[7] = Physics2D.Raycast(transform.position + new Vector3(-1, 1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), right, Color.blue);



                hit[8] = Physics2D.Raycast(transform.position + new Vector3(-1, 1, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, 1, 0), right, Color.red);

                hit[9] = Physics2D.Raycast(transform.position + new Vector3(0f, 0.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1, .5f, 0), right, Color.blue);

                hit[10] = Physics2D.Raycast(transform.position + new Vector3(0f, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), right, Color.red);



                //Second brick Raycasts
                hit[11] = Physics2D.Raycast(transform.position + new Vector3(0, -.5f, 0), Vector2.right, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(1f, -.5f, 0), right, Color.red);
                //down
                hit[12] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -1.5f, 0), right, Color.red);
                //Middle
                hit[13] = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -1f, 0), right, Color.red);

                if (hit[7] == true || hit[8] == true || hit[9] == true || hit[10] == true || hit[11] == true || hit[12] == true || hit[13] == true)
                {
                    rightRaycast = true;

                }

                else if (hit[7] == false || hit[8] == false || hit[9] == false || hit[10] == false || hit[11] == false || hit[12] == false || hit[13] == false)
                {
                    rightRaycast = false;
                }


                if (hit[17] == true)
                {
                    Debug.Log("Touched");
                }
            }

          
        }
    }

    private void T_Shaped()
    {
        if (GetComponentInChildren<RayCastingBricks>().typeOfTetro == RayCastingBricks.TypeOfTetro.T)
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

                hit[3] = Physics2D.Raycast(transform.position + new Vector3(0f, 1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-0, 1, 0), left, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(-1f, 1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), left, Color.blue);

                if (hit[0] == true || hit[1] == true || hit[2] == true || hit[3] == true || hit[4] == true)
                {
                    leftRaycast = true;

                    //turn of Left movement
                }

                else if (hit[0] == false || hit[1] == false || hit[2] == false)
                {
                    leftRaycast = false;
                }





                //Right Raycasts
                Vector2 right = (transform.TransformDirection(Vector2.right)) * raycastDistance;


                hit[3] = Physics2D.Raycast(transform.position + new Vector3(0f, 1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0f, 1.5f, 0), right, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(0, 1f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, 1f, 0), right, Color.blue);


                hit[5] = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0.5f, 0), Vector2.right, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(1f, .5f, 0), right, Color.blue);

                hit[6] = Physics2D.Raycast(transform.position + new Vector3(0f, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), right, Color.red);

                hit[7] = Physics2D.Raycast(transform.position + new Vector3(0.5f, -.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -.5f, 0), right, Color.magenta);




                if (hit[3] == true || hit[4] == true || hit[5] == true || hit[6] == true || hit[7] == true)
                {
                    rightRaycast = true;

                    //turn of Left movement
                }

                else if (hit[3] == false || hit[4] == false || hit[5] == false || hit[6] == false || hit[7] == false)
                {
                    rightRaycast = false;
                }




            }

            if (GetComponentInChildren<RayCastingBricks>().rotations == RayCastingBricks.Rotations.Ninety)
            {



                Vector2 left = (transform.TransformDirection(Vector2.down)) * raycastDistance;
                //up block raycasts


                hit[0] = Physics2D.Raycast(transform.position + new Vector3(0, 1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1, 1.5f, 0), left, Color.red);



                hit[1] = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1, 1, 0), left, Color.red);

                hit[2] = Physics2D.Raycast(transform.position + new Vector3(-1, 0.5f, 0), Vector2.left, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(-2f, .5f, 0), left, Color.red);

                hit[3] = Physics2D.Raycast(transform.position + new Vector3(-1, 0, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-2f, 0, 0), left, Color.red);


                //Second brick Raycasts
                hit[4] = Physics2D.Raycast(transform.position + new Vector3(-1, -.5f, 0), Vector2.left, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(-2f, -.5f, 0), left, Color.red);
                //down
                hit[5] = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -1, 0), left, Color.red);
                //Middle
                hit[6] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.left, raycastDistance, groundLayer);
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


                hit[7] = Physics2D.Raycast(transform.position + new Vector3(0, 1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 1.5f, 0), right, Color.red);



                hit[8] = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 1, 0), right, Color.red);

                hit[9] = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), Vector2.right, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(1f, .5f, 0), right, Color.red);

                hit[10] = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), right, Color.red);



                //Second brick Raycasts
                hit[11] = Physics2D.Raycast(transform.position + new Vector3(0, -.5f, 0), Vector2.right, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(1f, -.5f, 0), right, Color.red);
                //down
                hit[12] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -1.5f, 0), right, Color.red);
                //Middle
                hit[13] = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -1f, 0), right, Color.red);

                if (hit[7] == true || hit[8] == true || hit[9] == true || hit[10] == true || hit[11] == true || hit[12] == true || hit[13] == true)
                {
                    rightRaycast = true;

                }

                else if (hit[7] == false || hit[8] == false || hit[9] == false || hit[10] == false || hit[11] == false || hit[12] == false || hit[13] == false)
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

                hit[3] = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -1, 0), left, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -1.5f, 0), left, Color.blue);

                if (hit[0] == true || hit[1] == true || hit[2] == true || hit[3] == true || hit[4] == true)
                {
                    rightRaycast = true;

                    //turn of Left movement
                }

                else if (hit[0] == false || hit[1] == false || hit[2] == false || hit[3] == false || hit[4] == false)
                {
                    rightRaycast = false;
                }




                Vector2 right = (transform.TransformDirection(Vector2.right)) * raycastDistance;


                hit[3] = Physics2D.Raycast(transform.position + new Vector3(-.5f, 0.4f, 0), Vector2.left, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(-1f, .4f, 0), right, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(-.5f, 0, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), right, Color.green);

                hit[5] = Physics2D.Raycast(transform.position + new Vector3(-.5f, -.4f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(-1f, -.4f, 0), right, Color.red);


                hit[6] = Physics2D.Raycast(transform.position + new Vector3(-.5f, -1.5f, 0), Vector2.left, raycastDistance, groundLayer);

                Debug.DrawRay(transform.position + new Vector3(0f, -1.5f, 0), right, Color.red);

                hit[7] = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -1, 0), right, Color.green);

                if (hit[3] == true || hit[4] == true || hit[5] == true || hit[6] == true || hit[7] == true)
                {
                    leftRaycast = true;

                    //turn of Left movement
                }

                else if (hit[3] == false || hit[4] == false || hit[5] == false || hit[6] == false || hit[7] == false)
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


                hit[2] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -1.5f, 0), left, Color.red);



                hit[3] = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -1f, 0), left, Color.red);

                hit[4] = Physics2D.Raycast(transform.position + new Vector3(1, -.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1f, -.5f, 0), left, Color.red);

                hit[5] = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1, 0f, 0), left, Color.red);



                hit[6] = Physics2D.Raycast(transform.position + new Vector3(1, .5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(1, .5f, 0), left, Color.red);

                hit[7] = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, 1, 0), left, Color.red);

                hit[8] = Physics2D.Raycast(transform.position + new Vector3(0, 1.5f, 0), Vector2.right, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), left, Color.red);

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

                hit[11] = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -1.5f, 0), right, Color.red);



                hit[12] = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), Vector2.left, raycastDistance, groundLayer);
                Debug.DrawRay(transform.position + new Vector3(0, -1, 0), right, Color.red);

                hit[13] = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f, 0), Vector2.left, raycastDistance, groundLayer);

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

            }

        }
    }

    private void StoppingStraightRotation()
    {
        Vector2 rotation = (transform.TransformDirection(Vector2.up)) * wallDistance;
        hit[18] = Physics2D.Raycast(transform.position + new Vector3(1, 1, 0), Vector2.right, wallDistance, wallsMask);
        Debug.DrawRay(transform.position + new Vector3(2, 1, 0), rotation, Color.blue);

        if (hit[18] == true)
        {

            stopRotation = true;
        }

        else
            stopRotation = false;
    }
}
