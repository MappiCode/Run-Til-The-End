using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleBuilder : MonoBehaviour
{
    public float spawnPropability;

    [SerializeField] private Tile[] obstacleTiles;
    private Tilemap tm;

    private int tilesInARow = 0;
    private int tileGap = 0;

    private void Start()
    {
        tm = GetComponent<Tilemap>();
    }

    void OnGridMoved(int tilesMoved)
    {
        // Delete the obstacles behind the Player
        tm.SetTile(new Vector3Int(-10 + tilesMoved, -2, 0), null);
        

        if (spawnPropability > Random.value || tileGap > 10)
        {
            if(tilesInARow > 2 || tileGap < 3)
            {
                tilesInARow = 0;
                tileGap++;
                return;
            }

            Tile obstacle = obstacleTiles[Random.Range(0, obstacleTiles.Length)];

            // Place a new obstacle infront
            tm.SetTile(new Vector3Int(10 + tilesMoved, -2, 0), obstacle);

            tileGap = 0;
            tilesInARow++;
        }
        else
        {
            tilesInARow = 0;
            tileGap++;
        }

        tm.CompressBounds();
    }
}
