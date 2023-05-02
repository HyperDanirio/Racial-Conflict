using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2_Movement_Melee : MonoBehaviour
{
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
        float distance = Vector3.Distance(transform.position, playerSoldier.transform.position);

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
