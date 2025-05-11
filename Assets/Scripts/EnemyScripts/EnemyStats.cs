using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeEnemy
{
    SIMPLE,
    BOSS
}
[CreateAssetMenu(fileName ="New Enemy Stats")]
public class EnemyStats : ScriptableObject
{

    public int Hp;
    public int Damage;
    public string Name;
    public float MovwSpeed;
    public float AttackSpeed;
    public TypeEnemy TypeEnemy;
    
}
