using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_1 : MonoBehaviour
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

    private GameObject enemySoldier;
    private bool attacking = false;

    void Start()
    {
        Debug.Log("Clone created in Spawn_2! " + tag);
        enemySoldier = GameObject.FindGameObjectWithTag("Soldier_Team_2");
       // Debug.Log(enemySoldier);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            SpawnObject();
        }
        GameObject[] respawns = GameObject.FindGameObjectsWithTag("Soldier_Team_2");
        bool isAttacking = false;
        foreach (GameObject respawn in respawns) {
            float distance = Vector2.Distance(gameObject.transform.position, respawn.transform.position);
            if (distance <= attackRange && !attacking) {
                StopMoving();
                StartCoroutine(Attack());
                isAttacking = true;
                break;
            }
        }

        //float distance = Vector2.Distance(gameObject.transform.position, enemySoldier.transform.position);

        // if (distance <= attackRange && !attacking)
        // {
        //     StopMoving();
        //     StartCoroutine(Attack());
        // }
        // else
        if (!isAttacking)
        {
            //Debug.Log("TEST " + distance + " " + attackRange);
            MoveRight();
        }
    }
    public void SpawnObject()
    {
        if (object_to_spawn<max_object_to_spawn) {
            Vector3 spawnPosition = new Vector3(spawn_location_x, spawn_location_y, 0);
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            object_to_spawn++;
        }
    
    }

 IEnumerator Attack()
    {
        attacking = true;

        yield return new WaitForSeconds(attackDelay);

        float distance = Vector3.Distance(transform.position, enemySoldier.transform.position);
        if (distance <= attackRange)
        {
            Debug.Log("Player took " + damage + " damage!");
        }
        attacking = false;
    }

    void MoveRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void StopMoving()
    {
        speed = 0;
    }
}
