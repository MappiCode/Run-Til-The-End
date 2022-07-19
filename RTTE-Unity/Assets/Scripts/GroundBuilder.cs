using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundBuilder : MonoBehaviour
{
    [SerializeField] private Tile groundTile;

    private Tilemap tm;
    private float lastX = 0f;
    private int numAddedPieces = 0;

    private void Awake()
    {
        tm = GetComponent<Tilemap>();
    }

    void Start()
    {
        tm.CompressBounds();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < (lastX - 4f))
        {
            lastX = transform.position.x;
            
            // Delete the ground behind the Player
            tm.SetTile(new Vector3Int(-10 + numAddedPieces * 4, -2, 0), null);
            
            // Add a new groundTile infront
            tm.SetTile(new Vector3Int(18 + numAddedPieces * 4, -2, 0), groundTile);

            tm.CompressBounds();
            numAddedPieces++;
        }
    }
}
