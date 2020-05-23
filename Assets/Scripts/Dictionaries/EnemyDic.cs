using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//将敌人数据存入字典
public class EnemyDic : MonoBehaviour
{
    public static Dictionary<int, EDic> enemyDic 
        = new Dictionary<int, EDic>();                              //申请字典

    public TextAsset Enemy;                                         //获取敌人数据文本
    
    void Awake()
    {
        ReadInfo();
    }

    //将敌人数据存入字典
    void ReadInfo()
    {
        string text = Enemy.text;                                   // 将文本内容作为字符串读取
        string[] EnemyArray = text.Split('\n');       // 以\n为分割符将文本分割为一个数组
        foreach (string str in EnemyArray)
        {
            EDic infoDic =new EDic();
            string[] enemyStrings = str.Split(',');
            int id=Int32.Parse(enemyStrings[0]);                    //敌人ID
            string name = enemyStrings[1];                          //敌人名字
            int Strength= Int32.Parse(enemyStrings[2]);             //敌人力量
            int Agility = Int32.Parse(enemyStrings[3]);             //敌人敏捷
            int Neili = Int32.Parse(enemyStrings[4]);               //敌人内力
            int Atk = Int32.Parse(enemyStrings[5]);                 //敌人攻击力
            int Speed = Int32.Parse(enemyStrings[6]);               //敌人速度
            float Dodge = float.Parse(enemyStrings[7]);             //敌人闪避
            int Armor = int.Parse(enemyStrings[8]);                 //敌人护甲
            float Magic = float.Parse(enemyStrings[9]);             //敌人法术伤害
            int MaxHp = int.Parse(enemyStrings[10]);                //敌人最大生命值
            float HpBack = float.Parse(enemyStrings[11]);           //敌人生命恢复
            int MaxMp = int.Parse(enemyStrings[12]);                //敌人最大法力值
            float MpBack = float.Parse(enemyStrings[13]);           //敌人法力值恢复
            int Sword = int.Parse(enemyStrings[14]);                //敌人剑法
            int Knife = int.Parse(enemyStrings[15]);                //敌人刀法
            int Stick = int.Parse(enemyStrings[16]);                //敌人棍法
            int Backstabber = int.Parse(enemyStrings[17]);          //敌人暗器
            int Leechcraft = int.Parse(enemyStrings[18]);           //敌人医术
            int Poisoning = int.Parse(enemyStrings[19]);            //敌人毒术
            int Lv = int.Parse(enemyStrings[20]);                   //敌人等级

            //敌人功法
            List<int> skillInts=new List<int>();
            for (int i = 21; i < enemyStrings.Length; i++)
            {
                skillInts.Add(int.Parse(enemyStrings[i]));
            }

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
            infoDic.Lv = Lv;
            infoDic.SkillInts = skillInts;


            enemyDic.Add(id, infoDic);                        // 将物品信息存储到字典中
        }
    }
}

//敌人字典模板
public class EDic
{
    public int Id;                              //敌人ID

    public string Name;                         //敌人名字

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

    public int Lv;                              //等级

    public List<int> SkillInts;                 //敌人功法
}