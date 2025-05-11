using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MontirovkaScript : MonoBehaviour,IWeapon
{
    public int Damage { get; set; }
    public int MaxMagazineSize { get; set; }
    public int CurrentMagazineBullets { get; set; }
    public int MaxBullets { get; set; }
    public int CurrentBullets { get; set; }
    public float AttackSpeed { get; set; }
    public float ReloadTime { get; set; }
    public GunType typeOfGun { get; set; }

    public GameObject Bullet;
    public Transform AttackPoint;
    //public Transform AttackPoint2;


    void Start()
    {
        Damage = 10;
        MaxMagazineSize = 0;
        CurrentBullets = MaxMagazineSize;
        MaxBullets = 00;
        AttackSpeed = 5;
        ReloadTime = 0;
        typeOfGun = GunType.MONTIROVKA;
    }

   

    public void Attack()
    {
        //if (CurrentBullets > 0) { 
        //    GameObject gm = Instantiate(Bullet, AttackPoint.position,transform.rotation);
        //    //GameObject gm2 = Instantiate(Bullet, AttackPoint2.position, transform.rotation);
        //    Vector2 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector2 myPosition = transform.position;
        //    Vector2 direction = mPosition - myPosition;
        //    gm.GetComponent<BulletScript>().BulletMove(direction);
        //    //gm2.GetComponent<BulletScript>().BulletMove(direction);

        //    CurrentBullets -= 1;

        //}
    }

    public void Reload()
    {
    //    if (Input.GetKeyDown(KeyCode.R) && CurrentBullets<MaxMagazineSize && MaxBullets>0)
    //    {
    //        int raznost = (MaxMagazineSize - CurrentBullets);

    //        if (MaxBullets > raznost) { 
    //            MaxBullets -= raznost;
    //            CurrentBullets += raznost;
    //        }
    //        else
    //        {
    //            int ost = raznost - MaxBullets;
    //            CurrentBullets += ost;
    //            MaxBullets = 0;
    //        }
                

    //    }

    }

   
}
