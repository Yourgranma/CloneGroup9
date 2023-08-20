using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisManager : MonoBehaviour
{
    public BlockSpawning blockSpawning;
    private GameObject spawnPoint;
    private void Awake()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawningBricks");

    }
    // Start is called before the first frame update
    void Start()
    {
        blockSpawning = spawnPoint.GetComponent<BlockSpawning>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
