using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palyer : MonoBehaviour
{
    [Header("玩家基本数值")]
    public float maxHP = 1000f;
    public float currentHP;
    public float maxStamina = 100f;
    [Header("耐力相关数值")]
    public float staminaReplyPerSecond = 15f;//每秒回复的体力值
    public float currentStamina;//现在的体力值
    public float jumpStaminaCost = 20f;//跳跃体力消耗
    public float AtkStaminaCost = 20f;//攻击体力消耗
    [Header("移动相关数值")]
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    [Header("检测相关 ")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;
    [Header("战斗相关")]
    public GameObject ATKArea;
    public Animator animator;
    public float playerDamage;
    private bool isATKing;
    //不可见变量
    private Rigidbody2D rb;
    private bool isGrounded;
    private float playerInput;
    private bool canRegenStamina = true;//是否允许回复体力
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentStamina = maxStamina;
        currentHP = maxHP;
        isATKing = true;
    }
    void Update()
    {
        Move();
        Jump();
        playerATK();
        replyStamina();
    }
    void Move()
    {
        if (!isATKing)
        {
             playerInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(playerInput * moveSpeed,rb.velocity.y);
            //后面这里是简单的转向
            if(playerInput >= 0)
            {
                transform.localScale = new Vector3(1,1,1);
            }
            else
            {
                transform.localScale = new Vector3(-1,1,1);
            }
        }
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W))
        {
            canRegenStamina = false;
            isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);
            if(isGrounded && currentStamina >= jumpStaminaCost)
            {
                canRegenStamina = false;
                rb.velocity = new Vector2(rb.velocity.x,jumpForce);
                //rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                ConSumeStamina(jumpStaminaCost);//体力花费函数
            }else if(currentStamina <= 20f){
                Debug.Log("体力不足，无法跳跃");
            }
        }else if(isGrounded){
            canRegenStamina = true;
        }
    }
    void playerATK()
    {
        if(Input.GetMouseButtonDown(0) && !isATKing)
        {
            if (currentStamina >= AtkStaminaCost)
            {
                ConSumeStamina(AtkStaminaCost);
                canRegenStamina = false;
                //攻击代码
            }
        }
    }
    //体力花费方法
    void ConSumeStamina(float cost)
    {
        currentStamina -= cost;
    }
    //体力回复方法
    void replyStamina()
    {
        if(canRegenStamina && currentStamina <= maxStamina)
        {
            currentStamina += staminaReplyPerSecond * Time.deltaTime;
        }
    }
}
