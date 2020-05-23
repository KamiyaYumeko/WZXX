using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//功法模板
[System.Serializable]
public class GFTemplate
{
    public int Id;                                                  //功法ID
    public string Name;                                             //功法名字
    public int Lv;                                                  //功法等级
    public int Strength;                                            //功法增加力量
    public int Agility;                                             //功法增加敏捷
    public int Neili;                                               //功法增加内力
    public int Atk;                                                 //功法增加攻击力
    public int Speed;                                               //功法增加速度
    public float Dodge;                                             //功法增加闪避
    public int Armor;                                               //功法增加护甲
    public float Magic;                                             //功法增加技能伤害
    public float MaxHp;                                             //功法增加最大血量
    public float HpBack;                                            //功法增加生命恢复
    public float MaxMp;                                             //功法增加最大法力值
    public float MpBack;                                            //功法增加法力恢复
    public string Information;                                      //功法介绍
}
