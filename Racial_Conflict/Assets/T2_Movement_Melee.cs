using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2_Movement_Melee : MonoBehaviour
{
    public float speed;
    public float attackRange = 2f;
    public float attackDelay = 1f;
    public int damage = 10;

    private GameObject playerSoldier;
    private bool attacking = false;

    void Start()
    {
        playerSoldier = GameObject.FindGameObjectWithTag("Soldier_Team_1");     
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerSoldier.transform.position);

        if (distance <= attackRange && !attacking)
        {
            // Stop moving when player soldier is in attack range
            StopMoving();
            StartCoroutine(Attack());
        }
        else
        {
            // Move in one direction if player soldier is not in attack range
            MoveRight();
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

    void MoveRight()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void StopMoving()
    {
        // Stop moving by setting the speed to 0
        speed = 0;
    }
}
