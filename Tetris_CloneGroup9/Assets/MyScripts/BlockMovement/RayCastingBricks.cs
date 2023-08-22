using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastingBricks : MonoBehaviour
{
    public enum Rotations { Zero, Ninety, OneEighty, MinusNinety, ThreeSixty}
    public Rotations rotations;
    public enum TypeOfTetro { Straight, L, Skwe, Square}
    public TypeOfTetro typeOfTetro;
    public float raycastDistance = .5f;
    public LayerMask groundLayer;
    int layerMaskWithoutSelf;



    public RaycastHit2D[] hit=new RaycastHit2D[5];


    //References
    private GameObject gameManager;
    private TetrisManager _tetrisManager;

    public GameObject[] childObjects;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _tetrisManager = gameManager.GetComponent<TetrisManager>();

        int LayerIgnoreRayCast = LayerMask.NameToLayer("Ignore Raycast");
        gameObject.layer = LayerIgnoreRayCast;
    }

    // Start is called before the first frame update
    void Start()
    {

        int childCount = transform.childCount;
        childObjects = new GameObject[childCount];

        // Store each child in the array
        for (int j = 0; j < childCount; j++)
        {
            childObjects[j] = transform.GetChild(j).gameObject;
        }
        
        int i = 3;
        LayerMask changeLayer;
        changeLayer = i;
        rotations = Rotations.Zero;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastStraight();
        RaycastSquare();
        ObjRotation();
        
    }

    private void ObjRotation()
    {
        if (transform.rotation.eulerAngles.z == 0)
        {
            rotations = Rotations.Zero;
        }

        else if (transform.rotation.eulerAngles.z == 90)
        {
            rotations = Rotations.Ninety;
        }

        else if (transform.rotation.eulerAngles.z == 180)
        {
            rotations = Rotations.OneEighty;
        }

        else if (transform.rotation.eulerAngles.z == 270)
        {
            rotations = Rotations.MinusNinety;
        }

        Debug.Log(transform.rotation.eulerAngles.z);
    }

    //for stopping The Tetromino from moving
    public void RaycastStraight()
    {
        if (typeOfTetro == TypeOfTetro.Straight)
        {
            if (_tetrisManager.blockSpawning.tetromino == BlockSpawning.Tetromino.Straight)
            {
                if (rotations == Rotations.Zero)
                {
                    hit[0] = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Vector2 down = (transform.TransformDirection(Vector2.down)) * raycastDistance;
                    Debug.DrawRay(transform.position, down, Color.blue);

                    hit[1] = Physics2D.Raycast(transform.position + new Vector3(-1f, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), down, Color.blue);

                    hit[2] = Physics2D.Raycast(transform.position + new Vector3(1f, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), down, Color.blue);

                    hit[3] = Physics2D.Raycast(transform.position + new Vector3(2f, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Debug.DrawRay(transform.position + new Vector3(2f, 0, 0), down, Color.blue);


                    StraightTetromino();

                }

                else if (rotations == Rotations.Ninety)
                {
                    hit[0] = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.down, raycastDistance, groundLayer);
                    Vector2 left = (transform.TransformDirection(Vector2.left)) * raycastDistance;
                    Debug.DrawRay(transform.position + new Vector3(0, -1f, 0), left, Color.blue);

                    StraightTetromino();

                }

                else if (rotations == Rotations.OneEighty)
                {
                    hit[0] = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Vector2 up = (transform.TransformDirection(Vector2.up)) * raycastDistance;
                    Debug.DrawRay(transform.position, up, Color.blue);

                    hit[1] = Physics2D.Raycast(transform.position + new Vector3(1f, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), up, Color.blue);

                    hit[2] = Physics2D.Raycast(transform.position + new Vector3(-1f, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), up, Color.blue);

                    hit[3] = Physics2D.Raycast(transform.position + new Vector3(-2f, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Debug.DrawRay(transform.position + new Vector3(-2f, 0, 0), up, Color.blue);

                    StraightTetromino();
                }
                
                else if (rotations == Rotations.MinusNinety)
                {
                    hit[0] = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, raycastDistance, groundLayer);
                    Vector2 right = (transform.TransformDirection(Vector2.right)) * raycastDistance;
                    Debug.DrawRay(transform.position + new Vector3(0, -2f, 0), right, Color.red);

                    StraightTetromino();
                }
            }
        }
        
        
    }

    public void RaycastSquare()
    {
        if (typeOfTetro == TypeOfTetro.Square)
        {
            //rotation must always be at zero
            Vector2 down = (transform.TransformDirection(Vector2.down)) ;
            hit[0] = Physics2D.Raycast(transform.position + new Vector3(.5f, -.5f, 0), Vector2.down, raycastDistance, groundLayer);
            Debug.DrawRay(transform.position + new Vector3(.5f, -.5f, 0), down, Color.blue);


            hit[1] = Physics2D.Raycast(transform.position + new Vector3(-.5f, -.5f, 0), Vector2.down, raycastDistance, groundLayer);
            Debug.DrawRay(transform.position + new Vector3(-.5f, -.5f, 0), down, Color.blue);

            StraightTetromino();
        }
    }
    private void StraightTetromino()
    {
        for (int i = 0; i <= 3; i++)
        {
            if (hit[i] == true)
            {
                int LayerIgnoreRayCast = LayerMask.NameToLayer("MainBrick");
                gameObject.layer = LayerIgnoreRayCast;

                for (int j = 0; j <= 3; j++)
                {

                    childObjects[j].layer = LayerIgnoreRayCast; ;
                    childObjects[j].transform.SetParent(null);
                }

                //Destroy(gameObject, .1f);
            }

        }
    }

    public void RaycastSkew()
    {

    }

    public void RaycastL()
    {

    }
}
