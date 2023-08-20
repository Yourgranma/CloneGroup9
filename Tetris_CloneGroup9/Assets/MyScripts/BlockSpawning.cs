using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawning : MonoBehaviour
{
    public bool spawning;
    public enum Tetromino{Straight, Square, T, L, Skew };
    public Tetromino tetromino;
    public Transform spawnPoint;
    public GameObject blockPrefab;

    public GameObject[] _tetromino = new GameObject[5];

    
    // Start is called before the first frame update
    void Start()
    {
        spawning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            RandomTetromino();
            SpawningBlocks();
            spawning = false;
        }
    }

    private void SpawningBlocks()
    {
        Instantiate(blockPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private void RandomTetromino()
    {
         int randomTetro = Random.Range(1, 5);
        switch (randomTetro)
        {
            
            case 1:
                blockPrefab = _tetromino[1];
                break;

            case 2:
                blockPrefab = _tetromino[2];
                break;

            case 3:
                blockPrefab = _tetromino[3];
                break;

            case 4:
                blockPrefab = _tetromino[4];
                break;

            case 5:
                blockPrefab = _tetromino[5];
                break;
        }
    }
}
