using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这个用来保存一系列玩家Player的数据，包括血量、护盾、异常状态、卡组、金币啥的。
public class PlayerManager : Singleton<PlayerManager>
{
    public int maxHealth = 100;
    public int currentHealth;

    [Tooltip("当前能够召唤出来的所有Cube类型，也就是玩家的卡组")]
    public List<GameObject> Deck = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> tempDeck = new List<GameObject>();
    //public GameObject[] Deck;

    [Header("Buff列表")]
    #region Buff列表 BuffList

    public int buffShield = 0;

    public int buffShieldMultiplyChip = 0;
    public int buffShieldMultiply = 0;

    public int buffAttackChip = 0;

    #endregion

    [Header("Act列表")]
    #region Act列表，ActList

    //因为Attack动作比较特殊，不同敌人会有自己独特的攻击节奏，所以多一个属性来描述
    public int actAttackNum = 0;
    public float actAttackTime = 0;//该攻击动作触发时间，必须大于0，若为0的话就默认改为5

    public int actArmorUpNum = 0;
    public float actArmorUpTime = 0;

    #endregion

    private new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        //TODO: 血量这里每次开战都回满，测试用的权宜之计。
        currentHealth = maxHealth;

        ResetTempDeck();
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
                currentHealth = 0;
                UIManager.Instance.Lose();
                BattleManager.Instance.GameOver();
            }
        }

        //更新UI显示
        UIManager.Instance.UpdateUI();
    }

    /// <summary>
    /// 重置所有Buff和Act
    /// </summary>
    public void ResetState()
    {
        buffShield = 0;

        actAttackNum = 0;
        actAttackTime = 0;
        actArmorUpNum = 0;
        actArmorUpTime = 0;
    }

    /// <summary>
    /// 把临时卡组tempDeck还原回玩家卡组Deck的内容
    /// </summary>
    public void ResetTempDeck()
    {
        tempDeck.Clear();
        foreach (GameObject item in Deck)
        {
            tempDeck.Add(item);
        }
    }
}
