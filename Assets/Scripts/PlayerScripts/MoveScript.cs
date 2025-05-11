using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScript : MonoBehaviour
{

    PlayerStats stats;
    Rigidbody2D rigidbody2D;
    Vector2 velocity;

    PlayerAnimator playerAnimator;
    AttackScript AttackScript;
    Animator animator;

    public GunType typeofgun;

    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        stats = gameObject.GetComponent<PlayerStats>();
        playerAnimator = GetComponent<PlayerAnimator>();
        AttackScript = GetComponent<AttackScript>();
        animator=GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            typeofgun = GunType.MONTIROVKA;
            stats.gun = FindObjectOfType<MontirovkaScript>();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            typeofgun = GunType.PISTOL;
            stats.gun = FindObjectOfType<PistolsScript>();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            typeofgun = GunType.AK;
            stats.gun = FindObjectOfType<AKScript>();
        }


        MoveWithGun(typeofgun);
        cursorRotate();
        playerAnimator.MoveAnimation(velocity.x*10, velocity.y*10);

    }

    private void FixedUpdate()
    {
        moveCharacter(velocity);
    }

    void moveCharacter(Vector3 direction)
    {
        rigidbody2D.velocity = direction * stats.MoveSpeed;
    }

    void cursorRotate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void MoveWithGun(GunType type)
    {
        if (type == GunType.MONTIROVKA)
        {
            animator.SetLayerWeight(2, 1);
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(3, 0);
        }
        else if (type == GunType.PISTOL)
        {
            animator.SetLayerWeight(1, 1);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(3, 0);
        }
        else if (type == GunType.AK)
        {
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(3, 1);
        }
        velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }

    public void TakeDamage(int damage)
    {
        stats.Hp -= damage;
        if (stats.Hp <= 0)
        {
            SceneManager.LoadScene(0);
           
        }
    }

    public void GetHeal(int value)
    {
        if (stats.Hp >= stats.MaxHp)
        {
            return;
        }
        else if (stats.Hp + value > stats.MaxHp)
        {
            stats.Hp = stats.MaxHp;
        }
        else
        {
            stats.Hp += value;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && stats.gun.typeOfGun==GunType.MONTIROVKA)
        {
            if (Input.GetMouseButtonDown(0)) { 
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(stats.gun.Damage);
            }
        }
    }
}
