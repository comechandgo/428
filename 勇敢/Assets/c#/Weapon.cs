using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            return; 
        }
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("砍到了敌人" + other.name);
            //这里后面可以加逻辑
            //特效，声音，震动之类的这些打击反馈
        }
    }
}
