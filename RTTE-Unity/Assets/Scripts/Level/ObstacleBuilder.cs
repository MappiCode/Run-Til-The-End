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

    [SerializeField] private Transform GroundSpawnPoint;
    [SerializeField] private Transform AirSpawnPoint;
 
    private int obstaclesInARow = 0;
    private int obstacleGap = 0;
    private bool allowMultiObstacles;

    void OnGridMoved(int tilesMoved)
    {
        if (spawnPropability > Random.value)
        {
            if (CheckCanPlaceObstacle())
            {
                ChooseAndPlaceObstacle();
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

    private void ChooseAndPlaceObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefab);
        obstacle.transform.parent = this.transform;

        Sprite sprite;
        if(1 < Random.Range(0, groundToAirRatio - 1) || obstaclesInARow > 0)
        {
            // ground obstacle
            sprite = groundObstacleSprites[Random.Range(0, groundObstacleSprites.Length)];
            obstacle.transform.position = GroundSpawnPoint.position;
            allowMultiObstacles = true;
        }
        else
        {
            // flying obstacle
            sprite = airObstacleSprites[Random.Range(0, airObstacleSprites.Length)];
            obstacle.transform.position = AirSpawnPoint.position;
            allowMultiObstacles = false;
        }
        obstacle.GetComponent<SpriteRenderer>().sprite = sprite;

        // reset collider to match sprite-shape
        obstacle.AddComponent<PolygonCollider2D>();
        obstacle.AddComponent<AddShadowCaster>().GenerateShadowCaster();


        obstacleGap = 0;
        obstaclesInARow++;
    }
}
