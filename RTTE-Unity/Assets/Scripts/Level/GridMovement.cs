using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private GameManager gm;
    
    [SerializeField] private float lvlSpeed = 1f;

    private int tilesMoved = 0;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (gm.gameIsPaused)
            return;

        transform.Translate(Vector3.left * lvlSpeed * gm.difficulty * Time.deltaTime);
        if (transform.position.x < -1 * tilesMoved)
        {
            BroadcastMessage("OnGridMoved", tilesMoved);
            tilesMoved++;
        }
    }
}
