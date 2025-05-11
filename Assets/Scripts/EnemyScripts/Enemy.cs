using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Enemy : MonoBehaviour
{
    public EnemyStats enemyStats;
    int currentHp;
    public GameObject healthBar;
    GameObject inst;
    float margin=1;
    public Canvas canvas;
    TMP_Text text;

    public Transform player;
    public float detectionRadius = 5f;
    public float chaseSpeed = 3.5f;
    public float roamTime = 3f;
    public float roamRadius = 3f;
    private Vector2 roamTarget;
    private bool isChasing = false;
    private Rigidbody2D rb;

    float delay = 2f;

    MoveScript playerStats;

    Coroutine Coroutine;

    bool isAttack = true;


   public GameObject[] drop;
   public int CountOfDrop;

    void Start()
    {
        inst=Instantiate(healthBar,transform.position,Quaternion.identity);
        inst.transform.parent=canvas.transform;
        currentHp=enemyStats.Hp;
        inst.GetComponent<Slider>().minValue = 0;
        inst.GetComponent<Slider>().maxValue = enemyStats.Hp;
        inst.GetComponent<Slider>().value = currentHp;
        text = inst.GetComponentInChildren<TMP_Text>();

        rb=GetComponent<Rigidbody2D>();
        SetNewRoamTarget();


    }
    private void Update()
    {
       
        inst.GetComponent<Slider>().value = currentHp;
        text.SetText(currentHp.ToString());
        Vector3 enemyPos = new Vector3(transform.position.x, transform.position.y + margin, 0);
        inst.GetComponent<Transform>().position=Camera.main.WorldToScreenPoint(new Vector3(enemyPos.x-1,enemyPos.y,0));

        float distancetoplayer = Vector2.Distance(transform.position, player.position);
        if (distancetoplayer < detectionRadius)
        {
            isChasing = true;  
        }
        else if(distancetoplayer > detectionRadius)
        {
            isChasing = false;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        Debug.Log(currentHp);
        if (currentHp <= 0)
        {
            SpawnLoot();
            Destroy(gameObject);
            Destroy(inst);
        }
    }

    private void FixedUpdate()
    {
        if (isChasing)
            ChasePlayer();
        else
            Roam();
    }

    void Roam()
    {
   
        MoveTowards(roamTarget,enemyStats.MovwSpeed);
        if (Vector2.Distance(transform.position, roamTarget) < 1)
            SetNewRoamTarget();

}

    private void SetNewRoamTarget()
    {
        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle*roamRadius;
        roamTarget = (Vector2)transform.position + randomOffset;
    }

    void MoveTowards(Vector2 target, float speed)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        rb.velocity = direction * speed;
        transform.right = (Vector3)roamTarget - transform.position;


    }

    void ChasePlayer()
    {
        MoveTowards(player.position, chaseSpeed);
        transform.right = player.position - transform.position;
        SetNewRoamTarget();


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerStats = collision.GetComponent<MoveScript>();
            playerStats.TakeDamage(enemyStats.Damage);
            isAttack = true;
            Coroutine = StartCoroutine(AttackWithDelay());
            Debug.Log("Start corutine");


        }

        else
            SetNewRoamTarget();


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        SetNewRoamTarget();

    }

    private IEnumerator AttackWithDelay()
    {
        while (isAttack)
        {
            yield return new WaitForSeconds(delay);
            playerStats.TakeDamage(enemyStats.Damage);
            Debug.Log("corutine is damage");
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Coroutine != null)
        {
            StopCoroutine(AttackWithDelay());
            Coroutine = null;
            Debug.Log("Stop corutine");
            isAttack = false;
        }
    }


    void SpawnLoot()
    {
        for(int i = 0; i < CountOfDrop; i++)
        {
            System.Random random = new System.Random();
            Vector3 point = GetRandomPosInRadius(gameObject.transform.position, 2);
            Instantiate(drop[random.Next(0, drop.Length-1)], point, Quaternion.identity);
        }
    }
    public Vector3 GetRandomPosInRadius(Vector3 centerPoint, float radius)
    {
        return centerPoint + (UnityEngine.Random.insideUnitSphere * radius);
    }
}
