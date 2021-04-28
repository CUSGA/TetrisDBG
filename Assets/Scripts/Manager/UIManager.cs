using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("玩家的状态栏")]
    //Player的血量滑动条、血量数字文本和Buff挂载物体
    public Image playerHealthSlider;
    public Text playerHealthText;
    public GameObject playerBuffHolder;
    public GameObject playerActHolder;

    [Header("敌人的状态栏")]
    //同上，只是Enemy的
    public Image enemyHealthSlider;
    public Text enemyHealthText;
    public GameObject enemyBuffHolder;
    public GameObject enemyActHolder;

    [Header("Buff和Act的预制体列表")]
    [Tooltip("所有的Buff预制体")]
    public GameObject[] AllBuffs;
    [Tooltip("所有的Act预制体")]
    public GameObject[] AllActs;

    [Header("别的")]
    public Tooltip tooltip;
    public GameObject deckExplorer;
    
    private float originalSize1;
    private float originalSize2;
    
    public void Start()
    {
        originalSize1 = playerHealthSlider.rectTransform.rect.width;
        originalSize2 = enemyHealthSlider.rectTransform.rect.width;
    }
    
    public void UpdateUI()
    {
        Debug.Log("更新UI");
        //更新Player相关的UI
        //更新Player的血量显示
        UpdatePlayerHealthUI();
        //更新Player的Buff显示
        UpdatePlayerBuffUI();
        //更新Player的Act显示
        UpdatePlayerActUI();
        
        //更新Enemy相关的UI
        UpdateEnemyHealthUI();
        UpdateEnemyBuffUI();
        UpdateEnemyActUI();
    }

    /// <summary>
    /// 更新Player的血量显示
    /// </summary>
    private void UpdatePlayerHealthUI()
    {
        playerHealthSlider.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize1 * (float)PlayerManager.Instance.currentHealth / (float)PlayerManager.Instance.maxHealth);
        playerHealthText.text = PlayerManager.Instance.currentHealth + "/" + PlayerManager.Instance.maxHealth;
    }

    /// <summary>
    /// 更新Player的Buff显示
    /// </summary>
    private void UpdatePlayerBuffUI()
    {
        if (PlayerManager.Instance.buffShield > 0)
        {
            //遍历查询playerBuffHolder下是否已经有Shield的Buff标志
            Transform buffObj = FindBuffObjectFromHolder(0, "Buff_Shield");
            if (buffObj != null)//若找到，也就是说当前已经有生成该buff物体，就更改它的显示数字
            {
                buffObj.GetComponent<Buff>().numText.text = PlayerManager.Instance.buffShield.ToString();
            }else//若没有找到，也就是说当前没有生成该buff物体，就生成一个并赋值修改显示数字
            {
                Buff b = Instantiate(AllBuffs[0], playerBuffHolder.transform).GetComponent<Buff>();
                b.numText.text = PlayerManager.Instance.buffShield.ToString();
                b.belong = 0;
            }
        }else//若buff数字小于等于0，就把当前有的buff物体删除掉
        {
            //遍历查询playerBuffHolder下是否已经有Shield的Buff标志
            Transform buffObj = FindBuffObjectFromHolder(0, "Buff_Shield");
            if (buffObj != null)
                Destroy(buffObj.gameObject);
        }

        if (PlayerManager.Instance.buffShieldMultiplyChip > 0)
        {
            //遍历查询playerBuffHolder下是否已经有Shield的Buff标志
            Transform buffObj = FindBuffObjectFromHolder(0, "Buff_ShieldMultiplyChip");
            if (buffObj != null)//若找到，也就是说当前已经有生成该buff物体，就更改它的显示数字
            {
                buffObj.GetComponent<Buff>().numText.text = PlayerManager.Instance.buffShieldMultiplyChip.ToString();
            }
            else//若没有找到，也就是说当前没有生成该buff物体，就生成一个并赋值修改显示数字
            {
                Buff b = Instantiate(AllBuffs[1], playerBuffHolder.transform).GetComponent<Buff>();
                b.numText.text = PlayerManager.Instance.buffShieldMultiplyChip.ToString();
                b.belong = 0;
            }
        }
        else//若buff数字小于等于0，就把当前有的buff物体删除掉
        {
            //遍历查询playerBuffHolder下是否已经有Shield的Buff标志
            Transform buffObj = FindBuffObjectFromHolder(0, "Buff_ShieldMultiplyChip");
            if (buffObj != null)
                Destroy(buffObj.gameObject);
        }

        if (PlayerManager.Instance.buffShieldMultiply > 0)
        {
            //遍历查询playerBuffHolder下是否已经有Shield的Buff标志
            Transform buffObj = FindBuffObjectFromHolder(0, "Buff_ShieldMultiply");
            if (buffObj != null)//若找到，也就是说当前已经有生成该buff物体，就更改它的显示数字
            {
                buffObj.GetComponent<Buff>().numText.text = PlayerManager.Instance.buffShieldMultiply.ToString();
            }
            else//若没有找到，也就是说当前没有生成该buff物体，就生成一个并赋值修改显示数字
            {
                Buff b = Instantiate(AllBuffs[2], playerBuffHolder.transform).GetComponent<Buff>();
                b.numText.text = PlayerManager.Instance.buffShieldMultiply.ToString();
                b.belong = 0;
            }
        }
        else//若buff数字小于等于0，就把当前有的buff物体删除掉
        {
            //遍历查询playerBuffHolder下是否已经有Shield的Buff标志
            Transform buffObj = FindBuffObjectFromHolder(0, "Buff_ShieldMultiply");
            if (buffObj != null)
                Destroy(buffObj.gameObject);
        }

        if (PlayerManager.Instance.buffAttackChip > 0)
        {
            //遍历查询playerBuffHolder下是否已经有Shield的Buff标志
            Transform buffObj = FindBuffObjectFromHolder(0, "Buff_AttackChip");//修改
            if (buffObj != null)//若找到，也就是说当前已经有生成该buff物体，就更改它的显示数字
            {
                buffObj.GetComponent<Buff>().numText.text = PlayerManager.Instance.buffAttackChip.ToString();//修改
            }
            else//若没有找到，也就是说当前没有生成该buff物体，就生成一个并赋值修改显示数字
            {
                Buff b = Instantiate(AllBuffs[3], playerBuffHolder.transform).GetComponent<Buff>();//修改
                b.numText.text = PlayerManager.Instance.buffAttackChip.ToString();//修改
                b.belong = 0;
            }
        }
        else//若buff数字小于等于0，就把当前有的buff物体删除掉
        {
            //遍历查询playerBuffHolder下是否已经有Shield的Buff标志
            Transform buffObj = FindBuffObjectFromHolder(0, "Buff_AttackChip");//修改
            if (buffObj != null)
                Destroy(buffObj.gameObject);
        }
    }

    private void UpdatePlayerActUI()
    {
        if (PlayerManager.Instance.actAttackNum > 0)
        {
            Transform actObj = FindBuffObjectFromHolder(2, "Act_Attack");
            if (actObj != null)
            {
                actObj.GetComponent<Act>().numText.text = PlayerManager.Instance.actAttackNum.ToString();
            }
            else
            {
                Act b = Instantiate(AllActs[0], playerActHolder.transform).GetComponent<Act>();
                b.numText.text = PlayerManager.Instance.actAttackNum.ToString();
                b.belong = 0;
            }
        }
        else
        {
            Transform actObj = FindBuffObjectFromHolder(2, "Act_Attack");
            if (actObj != null)
                Destroy(actObj.gameObject);
        }
    }

    private void UpdateEnemyHealthUI()
    {
        enemyHealthSlider.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize2 * (float)EnemyManager.Instance.currentEnemy.currentHealth / (float)EnemyManager.Instance.currentEnemy.maxHealth);
        enemyHealthText.text = EnemyManager.Instance.currentEnemy.currentHealth + "/" + EnemyManager.Instance.currentEnemy.maxHealth;
    }

    private void UpdateEnemyBuffUI()
    {
        if (EnemyManager.Instance.currentEnemy.buffShieldNum > 0)
        {
            Transform buffObj = FindBuffObjectFromHolder(1, "Buff_Shield");
            if (buffObj != null)//若找到，也就是说当前已经有生成该buff物体，就更改它的显示数字
            {
                buffObj.GetComponent<Buff>().numText.text = EnemyManager.Instance.currentEnemy.buffShieldNum.ToString();
            }
            else//若没有找到，也就是说当前没有生成该buff物体，就生成一个并赋值修改显示数字
            {
                Buff b = Instantiate(AllBuffs[0], enemyBuffHolder.transform).GetComponent<Buff>();
                b.numText.text = EnemyManager.Instance.currentEnemy.buffShieldNum.ToString();
                b.belong = 1;
            }
        }
        else//若buff数字小于等于0，就把当前有的buff物体删除掉
        {
            //遍历查询playerBuffHolder下是否已经有Shield的Buff标志
            Transform buffObj = FindBuffObjectFromHolder(1, "Buff_Shield");
            if (buffObj != null)
                Destroy(buffObj.gameObject);
        }

        if (EnemyManager.Instance.currentEnemy.buffPoisonNum > 0)
        {
            Transform buffObj = FindBuffObjectFromHolder(1, "Buff_Poison");
            if (buffObj != null)//若找到，也就是说当前已经有生成该buff物体，就更改它的显示数字
            {
                buffObj.GetComponent<Buff>().numText.text = EnemyManager.Instance.currentEnemy.buffPoisonNum.ToString();
            }
            else//若没有找到，也就是说当前没有生成该buff物体，就生成一个并赋值修改显示数字
            {
                Buff b = Instantiate(AllBuffs[4], enemyBuffHolder.transform).GetComponent<Buff>();
                b.numText.text = EnemyManager.Instance.currentEnemy.buffPoisonNum.ToString();
                b.belong = 1;
            }
        }
        else//若buff数字小于等于0，就把当前有的buff物体删除掉
        {
            //遍历查询playerBuffHolder下是否已经有Shield的Buff标志
            Transform buffObj = FindBuffObjectFromHolder(1, "Buff_Poison");
            if (buffObj != null)
                Destroy(buffObj.gameObject);
        }
    }

    private void UpdateEnemyActUI()
    {
        if (EnemyManager.Instance.currentEnemy.actAttackNum > 0)
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_Attack");
            if (actObj != null)
            {
                actObj.GetComponent<Act>().numText.text = EnemyManager.Instance.currentEnemy.actAttackNum.ToString();
            }
            else
            {
                Act b = Instantiate(AllActs[0], enemyActHolder.transform).GetComponent<Act>();
                b.numText.text = EnemyManager.Instance.currentEnemy.actAttackNum.ToString();
                b.belong = 1;
            }
        }
        else
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_Attack");
            if (actObj != null)
                Destroy(actObj.gameObject);
        }

        if (EnemyManager.Instance.currentEnemy.actArmorUpNum > 0)
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_ArmorUp");
            if (actObj != null)
            {
                actObj.GetComponent<Act>().numText.text = EnemyManager.Instance.currentEnemy.actArmorUpNum.ToString();
            }
            else
            {
                Act b = Instantiate(AllActs[1], enemyActHolder.transform).GetComponent<Act>();
                b.numText.text = EnemyManager.Instance.currentEnemy.actArmorUpNum.ToString();
                b.belong = 1;
            }
        }
        else
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_ArmorUp");
            if (actObj != null)
                Destroy(actObj.gameObject);
        }

        if (EnemyManager.Instance.currentEnemy.actAirRaidNum > 0)
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_AirRaid");
            if (actObj != null)
            {
                actObj.GetComponent<Act>().numText.text = EnemyManager.Instance.currentEnemy.actAirRaidNum.ToString();
            }
            else
            {
                Act b = Instantiate(AllActs[2], enemyActHolder.transform).GetComponent<Act>();
                b.numText.text = EnemyManager.Instance.currentEnemy.actAirRaidNum.ToString();
                b.belong = 1;
            }
        }
        else
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_AirRaid");
            if (actObj != null)
                Destroy(actObj.gameObject);
        }

        if (EnemyManager.Instance.currentEnemy.actTroubleMakerKingNum > 0)//修改
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_TroubleMakerKing");//修改
            if (actObj != null)
            {
                actObj.GetComponent<Act>().numText.text = EnemyManager.Instance.currentEnemy.actTroubleMakerKingNum.ToString();//修改
            }
            else
            {
                Act b = Instantiate(AllActs[3], enemyActHolder.transform).GetComponent<Act>();//修改
                b.numText.text = EnemyManager.Instance.currentEnemy.actTroubleMakerKingNum.ToString();//修改
                b.belong = 1;
            }
        }
        else
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_TroubleMakerKing");//修改
            if (actObj != null)
                Destroy(actObj.gameObject);
        }

        if (EnemyManager.Instance.currentEnemy.actTroubleIncreaseNum > 0)//修改
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_TroubleIncrease");//修改
            if (actObj != null)
            {
                actObj.GetComponent<Act>().numText.text = EnemyManager.Instance.currentEnemy.actTroubleIncreaseNum.ToString();//修改
            }
            else
            {
                Act b = Instantiate(AllActs[4], enemyActHolder.transform).GetComponent<Act>();//修改
                b.numText.text = EnemyManager.Instance.currentEnemy.actTroubleIncreaseNum.ToString();//修改
                b.belong = 1;
            }
        }
        else
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_TroubleIncrease");//修改
            if (actObj != null)
                Destroy(actObj.gameObject);
        }

    }

    /// <summary>
    /// 在指定的BuffHolder下寻找指定的buff物体并返回，若没找到就返回null
    /// </summary>
    /// <param name="t">0代表查找player的buffHolder，1代表enemy的，2代表player的act列表，3代表enemy的</param>
    /// <param name="buffName">要查找的buff名字，比如“Buff_Shield”</param>
    /// <returns></returns>
    public Transform FindBuffObjectFromHolder(int t, string buffName)
    {
        if (t == 0)
        {
            foreach (Transform item in playerBuffHolder.transform)
            {
                if (item.name == buffName + "(Clone)")//因为所有实例化的预制体后面都会跟一个这样的标识，所以在查找时也要加上
                {
                    return item;
                }
            }
            return null;
        } else if (t == 1)
        {
            foreach (Transform item in enemyBuffHolder.transform)
            {
                if (item.name == buffName + "(Clone)")
                {
                    return item;
                }
            }
            return null;
        }
        else if (t == 2)
        {
            foreach (Transform item in playerActHolder.transform)
            {
                if (item.name == buffName + "(Clone)")
                {
                    return item;
                }
            }
            return null;
        }
        else if (t == 3)
        {
            foreach (Transform item in enemyActHolder.transform)
            {
                if (item.name == buffName + "(Clone)")
                {
                    return item;
                }
            }
            return null;
        }

        Debug.LogError("在FindBuffObjectFromHolder中，输入的第一个参数t不符合规范（不是0或1）！");
        return null;
    }

    public void OpenDeckExplorer()
    {
        deckExplorer.SetActive(true);
    }
}
