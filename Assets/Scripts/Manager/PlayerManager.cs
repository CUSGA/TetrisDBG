using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这个用来保存一系列玩家Player的数据，包括血量、护盾、异常状态、卡组、金币啥的。
public class PlayerManager : Singleton<PlayerManager>
{
    public int maxHealth = 100;
    public int currentHealth;

    [Tooltip("当前能够召唤出来的所有Cube类型，也就是玩家的卡组")]
    public GameObject[] Deck;

    [Header("Buff列表")]
    #region Buff列表 BuffList

    public int buffShield = 0;

    #endregion

    [Header("Act列表")]
    #region Act列表，ActList

    //因为Attack动作比较特殊，不同敌人会有自己独特的攻击节奏，所以多一个属性来描述
    public int actAttack = 0;
    public int actAttackTime = 0;//该攻击动作触发时间，必须大于0，若为0的话就默认改为5

    public int actArmorUp = 0;

    #endregion

    private void Start()
    {
        //TODO: 血量这里每次开战都回满，测试用的权宜之计。
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Player被攻击
    /// </summary>
    /// <param name="dmg">被攻击的伤害量</param>
    public void BeAttack(int dmg)
    {
        //处理Buff，比如护盾，减伤等，然后减少血量
        if (dmg <= buffShield)
        {
            buffShield -= dmg;
        }else
        {
            int rdmg = dmg - buffShield;
            buffShield = 0;
            currentHealth -= rdmg;
            if (currentHealth <= 0)
            {
                //TODO: GAME OVER
                currentHealth = 0;
                Debug.LogWarning("GAME OVER");
            }
        }

        //更新UI显示
        UIManager.Instance.UpdateUI();
    }
}
