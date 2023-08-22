using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineClear : MonoBehaviour
{
    public GameObject[] brick = new GameObject[10];

    public List<GameObject> bricks = new List<GameObject>();
    public int numberOfColliders = 0;
    //GameObject[] objectsToDestroy = new GameObject[10];
    public int i;

    bool destroy;
    bool waitToAdd;
    // Start is called before the first frame update
    void Start()
    {
        destroy = false;
        waitToAdd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfColliders == 0)
        {
            for (int i = 0; i <= 9; i++)
            {
               // brick[i]=null;
            }
        }
          
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Brick")
        {
            bricks.Add(GameObject.Find(collision.name));
            //brick[numberOfColliders] = collision.gameObject;
            numberOfColliders++;
            if (numberOfColliders == 10)
            {
                StartCoroutine(Destroying());
            }
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (numberOfColliders == 10)
        {


            brick[0] = GameObject.Find(bricks[0].name);
            brick[1] = GameObject.Find(bricks[1].name);
            brick[2] = GameObject.Find(bricks[2].name);
            brick[3] = GameObject.Find(bricks[3].name);
            brick[4] = GameObject.Find(bricks[4].name);
            brick[5] = GameObject.Find(bricks[5].name);
            brick[6] = GameObject.Find(bricks[6].name);
            brick[7] = GameObject.Find(bricks[7].name);
            brick[8] = GameObject.Find(bricks[8].name);
            brick[9] = GameObject.Find(bricks[9].name);
            //Destroy(collision.gameObject, 2f);
            for (int i = 0; i <= 9; i++)
            {


                Destroy(brick[i]);

            }
            numberOfColliders = 0;
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag=="Brick")
        {
            //brick[numberOfColliders-1] = null;
            
            GameObject gameObjectoRemove = GameObject.Find(collision.name) ;
            bricks.Remove(gameObjectoRemove);
            --numberOfColliders;


        }
        
    }

    IEnumerator Destroying()
    {
        destroy = false;
        yield return new WaitForSeconds(2);
        destroy = true;
    }

   
}
