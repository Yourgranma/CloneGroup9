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

    RaycastHit2D[] hit=new RaycastHit2D[4];
    //References
    private GameObject gameManager;
    private TetrisManager _tetrisManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _tetrisManager = gameManager.GetComponent<TetrisManager>();
    }

    // Start is called before the first frame update
    void Start()
    {


        layerMaskWithoutSelf = groundLayer & ~(1 << gameObject.layer);

        rotations = Rotations.Zero;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastStraight();
        RayCastTests();
        if (transform.rotation.eulerAngles.z == 270)
        {
            //transform.Rotate(0, 0, -90);
        }

       
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

        else if (transform.rotation.eulerAngles.z ==270)
        {
            rotations = Rotations.MinusNinety;
        }

        Debug.Log(transform.rotation.eulerAngles.z);
    }

    private void RayCastTests()
    {

       
    }
    void RaycastSquare()
    {

    }

    void RaycastT()
    {

    }

    public void RaycastStraight()
    {
        if (typeOfTetro == TypeOfTetro.Straight)
        {
            if (_tetrisManager.blockSpawning.tetromino == BlockSpawning.Tetromino.Straight)
            {
                if (rotations == Rotations.Zero)
                {
                    hit[0] = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.down, raycastDistance, layerMaskWithoutSelf);
                    Vector2 down = (transform.TransformDirection(Vector2.down)) * raycastDistance;
                    Debug.DrawRay(transform.position, down, Color.blue);

                    hit[1] = Physics2D.Raycast(transform.position + new Vector3(-1f, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), down, Color.blue);

                    hit[2] = Physics2D.Raycast(transform.position + new Vector3(1f, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), down, Color.blue);

                    hit[3] = Physics2D.Raycast(transform.position + new Vector3(2f, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Debug.DrawRay(transform.position + new Vector3(2f, 0, 0), down, Color.blue);

                    Debug.Log(hit[0].collider.gameObject.name);
                    


                }

                else if (rotations == Rotations.Ninety)
                {
                    RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.left, raycastDistance, groundLayer);
                    Vector2 left = (transform.TransformDirection(Vector2.left)) * raycastDistance;
                    Debug.DrawRay(transform.position + new Vector3(0, -1f, 0), left, Color.blue);
                }

                else if (rotations == Rotations.OneEighty)
                {
                    RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.up, raycastDistance, groundLayer);
                    Vector2 Up = (transform.TransformDirection(Vector2.up)) * raycastDistance;
                    Debug.DrawRay(transform.position, Up, Color.blue);

                    RaycastHit2D hit3 = Physics2D.Raycast(transform.position + new Vector3(1f, 0, 0), Vector2.up, raycastDistance, groundLayer);
                    Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), Up, Color.blue);

                    RaycastHit2D hit4 = Physics2D.Raycast(transform.position + new Vector3(-1f, 0, 0), Vector2.up, raycastDistance, groundLayer);
                    Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), Up, Color.blue);

                    RaycastHit2D hit5 = Physics2D.Raycast(transform.position + new Vector3(-2f, 0, 0), Vector2.up, raycastDistance, groundLayer);
                    Debug.DrawRay(transform.position + new Vector3(-2f, 0, 0), Up, Color.blue);
                }
                
                else if (rotations == Rotations.MinusNinety)
                {
                    RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.right, raycastDistance, groundLayer);
                    Vector2 right = (transform.TransformDirection(Vector2.right)) * raycastDistance;
                    Debug.DrawRay(transform.position + new Vector3(0, -2f, 0), right, Color.red);
                }
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
