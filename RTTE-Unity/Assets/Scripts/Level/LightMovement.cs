using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{

    [SerializeField] private float lightMoveSpeed = 1f;

    private GameManager gm;
    private Coroutine moveCoroutine;

    private bool createdSuccessor = false;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    //private void FixedUpdate()
    //{
    //    if (gm.gameIsPaused)
    //        return;

    //    transform.Translate(Vector3.right * lightMoveSpeed * gm.difficulty * Time.deltaTime);
    //}

    private void Update()
    {   
        if (gm.gameIsPaused)
            return;
        
        if (moveCoroutine == null)
            moveCoroutine = StartCoroutine(MoveLight());

        if (!createdSuccessor)
            if (transform.position.x < 0)
            {
                SendMessageUpwards("CreateNewLight");
                createdSuccessor = true;
            }
        
        if (transform.position.x < -20)
            Destroy(gameObject);
    }

    IEnumerator MoveLight()
    {
        while (gm.gameIsPaused == false) 
        { 
            yield return new WaitForEndOfFrame();
            transform.Translate(Vector3.right * lightMoveSpeed * gm.difficulty * Time.deltaTime);
        }
    }
}
