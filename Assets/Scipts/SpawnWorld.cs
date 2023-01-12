using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWorld : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform spawnTransform;
    public void Spawn() { 
        Instantiate(spawnObject, spawnTransform.position, spawnTransform.rotation);
    }
}
