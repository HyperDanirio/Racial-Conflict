using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_1 : MonoBehaviour
{
    public GameObject objectToSpawn; 
    private int object_to_spawn=0;
    public int max_object_to_spawn=1;

    void Start()
    {
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            SpawnObject();
        }
    }
    public void SpawnObject()
{
    if(object_to_spawn<max_object_to_spawn){
    Vector3 spawnPosition = new Vector3(-10, 0, 0); 
    Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    object_to_spawn++;

    }
    
}
}
