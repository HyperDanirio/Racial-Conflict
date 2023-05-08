using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_2 : MonoBehaviour
{
    public GameObject objectToSpawn; 
    private int object_to_spawn=0;
    public int max_object_to_spawn=1;
    public int spawn_location_x;
    public int spawn_location_y;
    public float speed = 0.5f;
    public float attackRange = 2f;
    public float attackDelay = 2f;
    public int damage = 10;

    private GameObject playerSoldier;
    private bool attacking = false;

    void Start()
    {
        playerSoldier = GameObject.FindGameObjectWithTag("Soldier_Team_1");  
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            SpawnObject();
        }
        float distance = Vector2.Distance(transform.position, playerSoldier.transform.position);

        if (distance <= attackRange && !attacking)
        {
            StopMoving();
            StartCoroutine(Attack());
        }
        else
        {
            MoveLeft();
        }
    }
    public void SpawnObject()
    {
    if(object_to_spawn<max_object_to_spawn){
    Vector3 spawnPosition = new Vector3(spawn_location_x, spawn_location_y, -1); 
    Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    object_to_spawn++;

    }
    
    }   
IEnumerator Attack()
    {
        attacking = true;

        yield return new WaitForSeconds(attackDelay);

        float distance = Vector3.Distance(transform.position, playerSoldier.transform.position);
        if (distance <= attackRange)
        {
            Debug.Log("Enemy took " + damage + " damage!");
        }

        attacking = false;
    }

    void MoveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void StopMoving()
    {
        speed = 0;
    }
}
