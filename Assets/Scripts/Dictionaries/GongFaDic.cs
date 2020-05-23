using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//功法词典
public class GongFaDic : MonoBehaviour
{
    public static Dictionary<int, GDic> GongfDic
        = new Dictionary<int, GDic>();                              //申请字典

    public TextAsset Gongfa;                                        //获取功法数据文本

    void Awake()
    {
        ReadInfo();
    }
    //将功法数据存入词典
    void ReadInfo()
    {
        string text = Gongfa.text;                                  //将文本内容作为字符串读取
        string[] GongArray = text.Split('\n');        //以\n为分割符将文本分割为一个数组
        foreach (string str in GongArray)
        {
            GDic infoDic = new GDic();
            string[] GongStrings = str.Split(',');
            int id = Int32.Parse(GongStrings[0]);                   //功法ID
            string name = GongStrings[1];                           //功法名字
            int strength = Int32.Parse(GongStrings[2]);             //功法增加力量
            int agility = Int32.Parse(GongStrings[3]);              //功法增加敏捷
            int neili = Int32.Parse(GongStrings[4]);                //功法增加内力
            int atk = Int32.Parse(GongStrings[5]);                  //功法增加攻击力
            int speed = Int32.Parse(GongStrings[6]);                //功法增加速度
            float dodge = float.Parse(GongStrings[7]);              //功法增加闪避
            int armor = int.Parse(GongStrings[8]);                  //功法增加护甲
            float magic = float.Parse(GongStrings[9]);              //功法增加技能伤害
            float maxHp = float.Parse(GongStrings[10]);             //功法增加最大血量
            float hpBack = float.Parse(GongStrings[11]);            //功法增加生命恢复
            float maxMp = float.Parse(GongStrings[12]);             //功法增加最大法力值
            float mpBack = float.Parse(GongStrings[13]);            //功法增加法力恢复
            string information = GongStrings[14];                   //功法介绍

            infoDic.Id = id;
            infoDic.Name = name;
            infoDic.Strength = strength;
            infoDic.Agility = agility;
            infoDic.Neili = neili;
            infoDic.Atk = atk;
            infoDic.Speed = speed;
            infoDic.Dodge = dodge;
            infoDic.Armor = armor;
            infoDic.Magic = magic;
            infoDic.MaxHp = maxHp;
            infoDic.HpBack = hpBack;
            infoDic.MaxMp = maxMp;
            infoDic.MpBack = mpBack;
            infoDic.Information = information;

            // 将物品信息存储到字典中
            GongfDic.Add(id, infoDic);
        }
    }
}

//功法词典模板
public class GDic
{
    public int Id;                                                  //功法ID
    public string Name;                                             //功法名字
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