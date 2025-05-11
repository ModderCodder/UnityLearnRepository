using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    PlayerStats Stats;
    PlayerAnimator PlayerAnimator;
    


    void Start()
    {
        Stats = GetComponent<PlayerStats>();
        PlayerAnimator = GetComponent<PlayerAnimator>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Attack(Stats.gun);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload(Stats.gun);

        }

    }

    void Attack(IWeapon weapon)
    {
        PlayerAnimator.AttackAnimation(weapon.typeOfGun);
        weapon.Attack();
                      
    }
    void Reload(IWeapon weapon) {
        weapon.Reload();
    }

}
