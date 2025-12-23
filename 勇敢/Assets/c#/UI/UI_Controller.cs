using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [Header("血条图片")]
    public Image HealthFilled;
    public Image HealthFilledDelay;
    public Image PowerFilled;

    [Header("广播血量变化")]
    public CharacterSO theCS;


    private void Start()
    {
        HealthFilledDelay.fillAmount = HealthFilled.fillAmount;
    }

    private void FixedUpdate()
    {
        HealthBarChangeDelay();
    }

    private void HealthBarChange(float percentage)
    {
        HealthFilled.fillAmount = percentage;
    }

    private void HealthBarChangeDelay()
    {
        if(HealthFilledDelay.fillAmount > HealthFilled.fillAmount)
            HealthFilledDelay.fillAmount -= Time.deltaTime;
    }

    private void PowerBarChange(float percentage)
    {
        PowerFilled.fillAmount = percentage;
    }

    private void OnEnable()
    {
        theCS.onBasicBarRaise += BasicBarEvent;
    }

    private void OnDisable()
    {
        theCS.onBasicBarRaise -= BasicBarEvent;
    }

    private void BasicBarEvent(player Player)
    {
        var HPpercentage = Player.currentHP / Player.maxHP;//血条变化
        HealthBarChange(HPpercentage);

        var PowerPercentage = Player.currentStamina / Player.maxStamina;//体力条变化
        PowerBarChange(PowerPercentage);
    }
}
