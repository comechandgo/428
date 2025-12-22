using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [Header("连招相关")]
    public float comboTime;
    private int comboStep = 1;
    private float windowTimer;
    public player Player;
    [Header("寸止相关")]
    public bool comboWindowOpen;
    public bool canCombo;//是否能够连招
    void Start()
    {
        comboTime = 1.8f;
        comboWindowOpen = false;
        windowTimer = 1f;
    }
    void Update()
    {
        if (comboWindowOpen)
        {
            windowTimer -= Time.deltaTime;
            if(windowTimer <= 0)
            {
                //如果没有在连招期间连招，重置状态
                comboStep = 1;
                comboWindowOpen = false;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            inAttak();
            normalATK();
        }
    }
    public void normalATK()
    {
        Debug.Log(comboStep);
        if(comboWindowOpen&&comboStep == 4)
        {
            comboStep = 1;   
        }
        if(comboStep == 1)
        {
            //如果首次开始攻击
            Attack(comboStep);
            comboWindowOpen = false;
            comboStep++;
        }
        else if (comboWindowOpen)
        {
            //如果正在连招中
            if(comboStep == 2)
            {
                Attack(comboStep);
                comboWindowOpen = false;
                comboStep++;
            }
            else if(comboStep == 3)
            {
                Debug.Log("本来是第三段攻击的"+comboStep);
                Attack(comboStep);
                comboWindowOpen = false;
                comboStep++;
            }
        }
        else
        {
            Debug.Log("按早了");
        }
    }
    public void Attack(int comboStep)
    {
        Player.animator.SetInteger("normalATK",comboStep);
    }
    
    public IEnumerator Dash(float power,float duration)
    {
        Player.isATKing = true;
        Player.rb.AddForce(new Vector2(transform.localScale.x * 500f,0));
        yield return new WaitForSeconds(duration);
        Player.isATKing =false;
    }
    //这个函数挂载在了每个攻击动作的后摇帧处
    public void openComboWindow()
    {
        comboWindowOpen = true;
        windowTimer = comboTime;
    }
    //下面两个是检测是否进入子动画的函数，挂载在动画事件上面
    public void exitAttak()
    {
        Player.animator.SetBool("normalAttack",false);
    }
    public void inAttak()
    {
        Player.animator.SetBool("normalAttack",true);
    }
    //管理第三段攻击的冲刺的动画事件函数，让第三段攻击的冲刺能更自然
    public void dashAttack()
    {
        StartCoroutine(Dash(50,0.18f));
    }
}
