using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineClear : MonoBehaviour
{
    public GameObject[] brick = new GameObject[11];

    public int numberOfColliders = 0;

    public int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfColliders == 0)
        {
            for (int i = 0; i <= 10; i++)
            {
                brick[i]=null;
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
            for(int i = 0; i <= 10; i++)
            {
                Destroy(brick[i]);
            }
            numberOfColliders = 0;
        }
    }
}
