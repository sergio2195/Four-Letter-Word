using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInstantiateCube : MonoBehaviour
{
    [SerializeField]
    private GameObject companionCube;
    [SerializeField]
    private GameObject companionCubePrefab;
    [SerializeField]
    private Transform instanceTransfrom;
    private GameObject cloneCube;

    void Update()
    {
        if (companionCube == null)
        {
            Instantiate(companionCubePrefab, instanceTransfrom.position, Quaternion.identity);
            companionCube = this.companionCubePrefab;
        }
    }
}
