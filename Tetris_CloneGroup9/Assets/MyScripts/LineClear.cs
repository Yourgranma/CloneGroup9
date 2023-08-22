using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineClear : MonoBehaviour
{
    GameObject[] brick = new GameObject[11];

    public int numberOfColliders = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfColliders == 10)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Brick")
        {
            numberOfColliders++;
        }

        if (numberOfColliders == 10)
        {
            Destroy(collision.gameObject);
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (numberOfColliders == 10)
        {
            Destroy(collision.gameObject);
            numberOfColliders = 0;
        }
    }
}
