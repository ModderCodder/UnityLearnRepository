using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    Animator animator;
    PlayerStats playerStats;
    public GameObject[] drop;
    public int CountOfDrop;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerStats = FindObjectOfType<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && playerStats.Keys>0)
        {
            Collider2D collider2D = GetComponent<BoxCollider2D>();
            collider2D.enabled = false;
            animator.SetTrigger("isOpen");
            playerStats.Keys -= 1;
            Destroy(gameObject, 3);
            SpawnLoot();
        }
    }

    void SpawnLoot()
    {
        for (int i = 0; i < CountOfDrop; i++)
        {
            System.Random random = new System.Random();
            Vector3 point = GetRandomPosInRadius(gameObject.transform.position, 2);
            Instantiate(drop[random.Next(0, drop.Length - 1)], point, Quaternion.identity);
        }
    }
    public Vector3 GetRandomPosInRadius(Vector3 centerPoint, float radius)
    {
        return centerPoint + (UnityEngine.Random.insideUnitSphere * radius);
    }
}
