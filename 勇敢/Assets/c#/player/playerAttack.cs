using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [Header("连招相关")]
    public float comboTime;
    private int comboStep;
    private float LastClickTime;
    public player Player;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("GetMouse");
            if(Player.currentStamina >= Player.AtkStaminaCost)
            {
                normalATK();   
            }
        }    
    }
    public void normalATK()
    {
        if(Time.time - LastClickTime >= comboTime)
        {
            comboStep = 0;
        }
        Player.animator.SetTrigger("TriggerATK");
        LastClickTime = Time.time;
        comboStep++;
        Player.ConSumeStamina(Player.AtkStaminaCost);
    }
}
