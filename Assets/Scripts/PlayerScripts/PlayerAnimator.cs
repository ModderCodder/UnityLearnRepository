using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    IWeapon type;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
    }

    public void MoveAnimation(float x,float y)
    {
        animator.SetFloat("XAxis",x);
        animator.SetFloat("YAxis", y);

    }

 

    public void GunAttackStop()
    {
        animator.SetInteger("GunType", 0);
    }


    public void AttackAnimation(GunType type)
    {
        if (type==GunType.MONTIROVKA)
            animator.SetInteger("GunType", 1);
        else if (type == GunType.PISTOL)
            animator.SetInteger("GunType", 2);
        else if (type == GunType.AK)
            animator.SetInteger("GunType", 3);
    }

}
