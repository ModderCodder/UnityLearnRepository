using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GunType
{
    PISTOL,
    AK,
    MONTIROVKA,
    IDLE
}
public interface IWeapon {
    public int Damage { get; set; }
    public int MaxMagazineSize { get; set;}
    public int CurrentMagazineBullets { get; set; }
    public int MaxBullets { get; set; }
    public int CurrentBullets { get; set; }
    public float AttackSpeed { get; set; }
    public float ReloadTime { get; set; }

    public void Attack();

    public void Reload();
    public GunType typeOfGun { get; set; }
    



}
