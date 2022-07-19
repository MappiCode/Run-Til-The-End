using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] private float lvlSpeed = 1f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * lvlSpeed * Time.deltaTime);
    }
}
