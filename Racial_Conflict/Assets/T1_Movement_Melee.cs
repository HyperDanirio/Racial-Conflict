using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1_Movement_Melee : MonoBehaviour
{
    public float speed = 0.5f;
    public float attackRange = 2f;
    public float attackDelay = 2f;
    public int damage = 10;

    private GameObject enemySoldier;
    private bool attacking = false;

    void Start()
    {
        enemySoldier = GameObject.FindGameObjectWithTag("Soldier_Team_2");     
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, enemySoldier.transform.position);

        if (distance <= attackRange && !attacking)
        {
            StopMoving();
            StartCoroutine(Attack());
        }
        else
        {
            MoveRight();
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
