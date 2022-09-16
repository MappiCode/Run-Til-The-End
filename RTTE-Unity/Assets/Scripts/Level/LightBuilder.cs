using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBuilder : MonoBehaviour
{
    [SerializeField] private GameObject lightPrefab;
    [SerializeField] private Vector3 firstObjPos;

    private GameObject l1;
    private GameObject l2;
    private GameObject l3;

    private void Start()
    {
        l1 = Instantiate(lightPrefab, transform);

        l1.transform.position = firstObjPos;
    }

    private void CreateNewLight()
    {
        GameObject newLight = Instantiate(lightPrefab, transform);
    }
}
