using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineClear : MonoBehaviour
{
    public GameObject[] brick = new GameObject[10];

    //public List<GameObject> bricks = new List<GameObject>();
    public int numberOfColliders = 0;
    //GameObject[] objectsToDestroy = new GameObject[10];
    public int i;

    bool destroy;
    // Start is called before the first frame update
    void Start()
    {
        destroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfColliders == 0)
        {
            for (int i = 0; i <= 9; i++)
            {
                brick[i]=null;
            }
        }

        if (destroy)
        {
            
            //Destroy(collision.gameObject, 2f);
            for (int i = 0; i <= 9; i++)
            {
                Destroy(brick[i]);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Brick")
        {
            
            brick[numberOfColliders] = collision.gameObject;
            numberOfColliders++;
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (numberOfColliders == 10)
        {
            StartCoroutine(Destroying());
            numberOfColliders = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Brick")
        {
            --numberOfColliders;
            //GameObject gameObjectoRemove = GameObject.Find(brick[numberOfColliders].name) ;
            brick[numberOfColliders] = null;

            //bricks.Remove(gameObjectoRemove);
            
            
        }
        
    }

    IEnumerator Destroying()
    {
        destroy = false;
        yield return new WaitForSeconds(2);
        destroy = true;
    }
}
