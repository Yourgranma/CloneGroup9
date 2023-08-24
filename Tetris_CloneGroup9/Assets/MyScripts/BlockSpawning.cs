using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawning : MonoBehaviour
{
    public bool spawning;
    public enum Tetromino{Blank, Straight, Square, T, L, Skew };
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
                tetromino = Tetromino.Square;
                blockPrefab = _tetromino[0];
                break;

            case 2:
                tetromino = Tetromino.L;
                blockPrefab = _tetromino[1];
                break;

            case 3:
                tetromino = Tetromino.Skew;
                blockPrefab = _tetromino[2];
                break;

            case 4:
                tetromino = Tetromino.Straight;

                blockPrefab = _tetromino[3];
                break;

            case 5:
                tetromino = Tetromino.T;
                blockPrefab = _tetromino[4];
                break;
        }
    }
}
