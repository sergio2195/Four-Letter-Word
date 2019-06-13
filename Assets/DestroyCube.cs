using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCube : MonoBehaviour
{
    [SerializeField]
    private Transform instanceTransfrom;
    [SerializeField]
    private GameObject companionCubePrefab;
    private bool instantiateCube;

    void Start()
    {
        instantiateCube = false;
        companionCubePrefab = this.gameObject;
    }

    void Update()
    {
        if (transform.position.y <= 75 && instantiateCube == false)
        {
            instantiateCube = true;
            Instantiate(companionCubePrefab, instanceTransfrom.position, Quaternion.identity);
            Destroy(this.gameObject, 5f);
        }
    }
}
