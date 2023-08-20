using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastingBricks : MonoBehaviour
{
    public enum Rotations { Zero, Ninety, OneEighty, MinusNinety, ThreeSixty}
    Rotations rotations;
    public enum TypeOfTetro { Straight, L, Skwe, Square}
    public TypeOfTetro typeOfTetro;
    public float raycastDistance = .5f;
    public LayerMask groundLayer;

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
        rotations = Rotations.MinusNinety;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastStraight();
        RayCastTests();
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
                    RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(0, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Vector2 down = (transform.TransformDirection(Vector2.down)) * raycastDistance;
                    Debug.DrawRay(transform.position, down, Color.blue);

                    RaycastHit2D hit3 = Physics2D.Raycast(transform.position + new Vector3(-1f, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Vector2 brick1Down = (transform.TransformDirection(Vector2.down)) * raycastDistance;
                    Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), down, Color.blue);

                    RaycastHit2D hit4 = Physics2D.Raycast(transform.position + new Vector3(1f, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Vector2 brick3Down = (transform.TransformDirection(Vector2.down)) * raycastDistance;
                    Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), down, Color.blue);

                    RaycastHit2D hit5 = Physics2D.Raycast(transform.position + new Vector3(2f, 0, 0), Vector2.down, raycastDistance, groundLayer);
                    Vector2 brick4Down = (transform.TransformDirection(Vector2.down)) * raycastDistance;
                    Debug.DrawRay(transform.position + new Vector3(2f, 0, 0), down, Color.blue);
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
                    Vector2 brick1up = (transform.TransformDirection(Vector2.up)) * raycastDistance;
                    Debug.DrawRay(transform.position + new Vector3(1f, 0, 0), Up, Color.blue);

                    RaycastHit2D hit4 = Physics2D.Raycast(transform.position + new Vector3(-1f, 0, 0), Vector2.up, raycastDistance, groundLayer);
                    Vector2 brick3up = (transform.TransformDirection(Vector2.up)) * raycastDistance;
                    Debug.DrawRay(transform.position + new Vector3(-1f, 0, 0), Up, Color.blue);

                    RaycastHit2D hit5 = Physics2D.Raycast(transform.position + new Vector3(-2f, 0, 0), Vector2.up, raycastDistance, groundLayer);
                    Vector2 brick4up = (transform.TransformDirection(Vector2.up)) * raycastDistance;
                    Debug.DrawRay(transform.position + new Vector3(-2f, 0, 0), Up, Color.blue);
                }
                
                else if (rotations == Rotations.MinusNinety)
                {
                    RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.left, raycastDistance, groundLayer);
                    Vector2 right = (transform.TransformDirection(Vector2.right)) * raycastDistance;
                    Debug.DrawRay(transform.position + new Vector3(0, -2f, 0), right, Color.blue);
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
