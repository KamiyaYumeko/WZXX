using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//装备词典
public class EquipDic : MonoBehaviour
{
    public static Dictionary<int, EqDic> equipDic
        = new Dictionary<int, EqDic>();                              //申请字典

    public TextAsset Equip;                                         //获取装备数据文本
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    //将装备数据存入字典
    void ReadInfo()
    {
        string text = Equip.text;                                   // 将文本内容作为字符串读取
        string[] EquipArray = text.Split('\n');       // 以\n为分割符将文本分割为一个数组
        foreach (string str in EquipArray)
        {
            EqDic infoDic = new EqDic();
            string[] equipStrings = str.Split(',');
            int id = Int32.Parse(equipStrings[0]);                  //装备ID
            string name = equipStrings[1];                          //装备名称
            int Strength = Int32.Parse(equipStrings[2]);            //装备力量
            int Agility = Int32.Parse(equipStrings[3]);             //装备敏捷
            int Neili = Int32.Parse(equipStrings[4]);               //装备内力
            int Atk = Int32.Parse(equipStrings[5]);                 //装备攻击力
            int Speed = Int32.Parse(equipStrings[6]);               //装备速度
            float Dodge = float.Parse(equipStrings[7]);             //装备闪避
            int Armor = int.Parse(equipStrings[8]);                 //装备护甲
            float Magic = float.Parse(equipStrings[9]);             //装备法术伤害
            int MaxHp = int.Parse(equipStrings[10]);                //装备最大生命值
            float HpBack = float.Parse(equipStrings[11]);           //装备生命恢复
            int MaxMp = int.Parse(equipStrings[12]);                //装备最大法力值
            float MpBack = float.Parse(equipStrings[13]);           //装备法力值恢复
            int Sword = int.Parse(equipStrings[14]);                //装备剑法
            int Knife = int.Parse(equipStrings[15]);                //装备刀法
            int Stick = int.Parse(equipStrings[16]);                //装备棍法
            int Backstabber = int.Parse(equipStrings[17]);          //装备暗器
            int Leechcraft = int.Parse(equipStrings[18]);           //装备医术
            int Poisoning = int.Parse(equipStrings[19]);            //装备毒术
            string Information = equipStrings[20];                  //装备介绍
            int Type = int.Parse(equipStrings[21]);                 //装备类型

            infoDic.Id = id;
            infoDic.Name = name;
            infoDic.Strength = Strength;
            infoDic.Agility = Agility;
            infoDic.Neili = Neili;
            infoDic.Atk = Atk;
            infoDic.Speed = Speed;
            infoDic.Dodge = Dodge;
            infoDic.Armor = Armor;
            infoDic.Magic = Magic;
            infoDic.MaxHp = MaxHp;
            infoDic.HpBack = HpBack;
            infoDic.MaxMp = MaxMp;
            infoDic.MpBack = MpBack;
            infoDic.Sword = Sword;
            infoDic.Knife = Knife;
            infoDic.Stick = Stick;
            infoDic.Backstabber = Backstabber;
            infoDic.Leechcraft = Leechcraft;
            infoDic.Poisoning = Poisoning;
            infoDic.Information = Information;
            infoDic.Type = Type;
        }
    }
}

//装备词典模板
public class EqDic
{
    public int Id;                              //装备ID
                                                  
    public string Name;                         //装备名字

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