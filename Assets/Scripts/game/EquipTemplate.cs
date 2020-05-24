using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//装备模板
[System.Serializable]
public class EquipTemplate
{
    public int Id;                              //装备ID

    public string Name;                         //装备名字

    public int Lv;                              //装备等级

    public int Strength;                        //力量 提供攻击力和血量 1力量提供1攻击力，5HP

    public int Agility;                         //敏捷 提供速度和闪避 1敏捷提供1%速度和闪避

    public int Neili;                           //内力 提供蓝量和法术伤害 1内力提供10MP，1%法伤

    public int Atk;                             //攻击力

    public int Speed;                           //速度

    public float Dodge;                         //闪避

    public int Armor;                           //护甲

    public float Magic;                         //法术伤害

    public int MaxHp;                           //最大生命值

    public float HpBack;                        //生命恢复

    public int MaxMp;                           //最大法力值

    public float MpBack;                        //法力值恢复

    public int Sword;                           //增加剑类技能伤害

    public int Knife;                           //增加刀类技能伤害

    public int Stick;                           //增加棍类技能伤害

    public int Backstabber;                     //增加暗器伤害

    public int Leechcraft;                      //增加治疗类技能回复

    public int Poisoning;                       //增加毒类技能伤害

    public string Information;                  //介绍

    public int Type;                            //类型
}
