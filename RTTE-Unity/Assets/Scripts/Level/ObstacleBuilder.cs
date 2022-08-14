using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleBuilder : MonoBehaviour
{
    [SerializeField] private float spawnPropability;
    [SerializeField] private float multiSpawnPropapility;
    [SerializeField] private float groundToAirRatio;

    [SerializeField] private TileBase[] groundObstacleTiles;
    [SerializeField] private TileBase[] airObstacleTiles;
    private Tilemap tm;

 
    private int tilesInARow = 0;
    private int tileGap = 0;
    private bool allowMultiTiles;
    private Vector3Int currentPosition;
    private int YGround = -2;
    private int YAir = -1;
    private int _YPos;

    private int YPos
    {
        get { return _YPos; }
        set 
        { 
            _YPos = value;
            currentPosition.y = value;
        }
    }

    private void Start()
    {
        tm = GetComponent<Tilemap>();
    }

    void OnGridMoved(int tilesMoved)
    {
        // Delete the obstacles behind the Player
        currentPosition = new Vector3Int(-10 + tilesMoved, YGround, 0);
        tm.SetTile(currentPosition, null);
        currentPosition.y++;
        tm.SetTile(currentPosition, null);


        currentPosition = new Vector3Int(10 + tilesMoved, YPos, 0);

        if (spawnPropability > Random.value)
        {
            if (CheckCanPlaceTile())
            {
                PlaceObstale(ChooseObstacle());
            }
            else
            {
                tilesInARow = 0;
                tileGap++;
            }
        }
    }

    private bool CheckCanPlaceTile()
    {
        if (tileGap < 5)
        {
            if (allowMultiTiles && tileGap == 0 && tilesInARow < 2 && multiSpawnPropapility > Random.value)
            {
                return true;
            }
            return false;
        }
        return true;
    }

    private TileBase ChooseObstacle()
    {
        TileBase obstacle;

        if(1 < Random.Range(0, groundToAirRatio - 1) || tilesInARow > 0)
        {
            // ground obstacle
            obstacle = groundObstacleTiles[Random.Range(0, groundObstacleTiles.Length)];
            YPos = YGround;
            allowMultiTiles = true;
        }
        else
        {
            // flying obstacle
            obstacle = airObstacleTiles[Random.Range(0, airObstacleTiles.Length)];
            YPos = YAir;
            allowMultiTiles = false;
        }

        return obstacle;
    }

    private void PlaceObstale(TileBase obstacle)
    {
        // Place a new obstacle infront
        tm.SetTile(currentPosition, obstacle);

        tileGap = 0;
        tilesInARow++;

        tm.CompressBounds();
    }
}
