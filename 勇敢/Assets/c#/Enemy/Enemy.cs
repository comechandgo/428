using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("怪物基本属性")]
    public float EnemyHP;                       //怪物血量
    public float EnemyMoveSpeed;                //怪物移动速度
    public float EnemyDamage;                   //怪物伤害
    [Header("战斗相关")]
    public Collider2D DamageArea;               //怪物伤害范围
    public Animator animator;                   //怪物的攻击动作
}
