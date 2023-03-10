using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1_Movement_Melee : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Enemy"))
    {
        Destroy(gameObject);
    }
}
}
