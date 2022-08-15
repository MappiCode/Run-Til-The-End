using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleBuilder : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnPropability;
    [SerializeField] private float multiSpawnPropapility;
    [SerializeField] private float groundToAirRatio;

    [SerializeField] private Sprite[] groundObstacleSprites;
    [SerializeField] private Sprite[] airObstacleSprites;
    [SerializeField] private TileBase[] groundObstacleTiles;
    [SerializeField] private TileBase[] airObstacleTiles;
    private Tilemap tm;

 
    private int obstaclesInARow = 0;
    private int obstacleGap = 0;
    private bool allowMultiObstacles;
    private Vector3 currentPosition;
    private float YGround = -1.5f;
    private float YAir = -0.5f;
    private float _YPos;

    private float YPos
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
        //currentPosition = new Vector3(-10 + tilesMoved, YGround, 0);
        //tm.SetTile(currentPosition, null);
        //currentPosition.y++;
        //tm.SetTile(currentPosition, null);


        currentPosition = new Vector3(10, YPos, 0);

        if (spawnPropability > Random.value)
        {
            if (CheckCanPlaceObstacle())
            {
                PlaceObstale(ChooseObstacle());
            }
            else
            {
                obstaclesInARow = 0;
                obstacleGap++;
            }
        }
    }

    private bool CheckCanPlaceObstacle()
    {
        if (obstacleGap < 5)
        {
            if (allowMultiObstacles && obstacleGap == 0 && obstaclesInARow < 2 && multiSpawnPropapility > Random.value)
            {
                return true;
            }
            return false;
        }
        return true;
    }

    private GameObject ChooseObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefab);
        obstacle.transform.parent = this.transform;

        Sprite sprite;
        if(1 < Random.Range(0, groundToAirRatio - 1) || obstaclesInARow > 0)
        {
            // ground obstacle
            sprite = groundObstacleSprites[Random.Range(0, groundObstacleSprites.Length)];
            YPos = YGround;
            allowMultiObstacles = true;
        }
        else
        {
            // flying obstacle
            sprite = airObstacleSprites[Random.Range(0, airObstacleSprites.Length)];
            YPos = YAir;
            allowMultiObstacles = false;
        }
        obstacle.GetComponent<SpriteRenderer>().sprite = sprite;

        // reset collider to match sprite-shape
        obstacle.AddComponent<PolygonCollider2D>();

        obstacle.AddComponent<AddShadowCaster>().GenerateShadowCaster();
        
        return obstacle;
    }

    private void PlaceObstale(GameObject obstacle)
    {
        // Place a new obstacle infront
        obstacle.transform.position = currentPosition;

        obstacleGap = 0;
        obstaclesInARow++;

        tm.CompressBounds();
    }
}
