using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//所有Enemy的父类，用来保存Enemy的数据、挂Buff和Action，承受攻击等
public class Enemy : MonoBehaviour
{
    public Sprite img;
    public string enemyName;//因为和GameObject的name冲突了，所以改个奇怪点的名字
    public int maxHealth;
    public int currentHealth;

    [Header("Buff列表")]
    #region Buff列表，BuffList

    public int buffShield = 0;

    #endregion

    [Header("Act列表")]
    #region Act列表，ActList

    //因为Attack动作比较特殊，不同敌人会有自己独特的攻击节奏，所以多一个属性来描述
    public int actAttack = 0;
    public float actAttackTime = 0;//该攻击动作触发时间，必须大于0，若为0的话就默认改为5

    public int actArmorUp = 0;

    #endregion

    protected void Start()
    {
        //TODO: 血量这里每次开战都回满，测试用的权宜之计。
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Enemy被攻击
    /// </summary>
    /// <param name="dmg">被攻击的伤害量</param>
    public void BeAttack(int dmg)
    {
        Debug.Log("敌人受到攻击：" + dmg + "点");
        if (dmg <= buffShield)
        {
            buffShield -= dmg;
        }
        else
        {
            int rdmg = dmg - buffShield;
            buffShield = 0;
            currentHealth -= rdmg;
            if (currentHealth <= 0)
            {
                //TODO: GAME OVER
                currentHealth = 0;
                Debug.LogWarning("WIN");
            }
        }

        //更新UI显示
        UIManager.Instance.UpdateUI();
    }
}
