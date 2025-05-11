using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float lifetime = 5f;
    PlayerStats stats;
    void Start()
    {
        stats=FindObjectOfType<PlayerStats>();
        Destroy(gameObject, lifetime);       

    }

    public void BulletMove(Vector3 direction, float attackspeed)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = direction.normalized * attackspeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(stats.gun.Damage);
            Destroy(gameObject);
        }
        else if (collision.tag == "Wall")
            Destroy(gameObject);

       
    }
}
