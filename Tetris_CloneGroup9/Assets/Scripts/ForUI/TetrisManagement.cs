using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisManagement : MonoBehaviour
{
    public CountingScrores _countingScore;
    private Piece _piece;

    private void Awake()
    {
        _piece = GameObject.FindGameObjectWithTag("Board").GetComponent<Piece>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        _countingScore = GetComponent<CountingScrores>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
