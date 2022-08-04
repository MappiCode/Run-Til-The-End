using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundBuilder : MonoBehaviour
{
    [SerializeField] private Tile groundTile;

    private Tilemap tm;
    private int numAddedPieces = 0;

    private void Awake()
    {
        tm = GetComponent<Tilemap>();
    }

    void Start()
    {
        tm.CompressBounds();
    }

    void Build()
    {
        // Delete the ground behind the Player
        tm.SetTile(new Vector3Int(-10 + numAddedPieces * 4, -2, 0), null);
            
        // Add a new groundTile infront
        tm.SetTile(new Vector3Int(18 + numAddedPieces * 4, -2, 0), groundTile);

        tm.CompressBounds();
        numAddedPieces++;
    }

    void OnGridMoved (int tilesMoved)
    {
        if (tilesMoved == 0)
            return;

        if (tilesMoved % 4 == 0)
            Build();
    }
}
