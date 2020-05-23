using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//技能词典
public class SkillDic : MonoBehaviour
{
    public static Dictionary<int, SDic> skillDic
        = new Dictionary<int, SDic>();                              //申请字典

    public TextAsset Skill;                                         //获取技能数据文本
    void Awake()
    {
        ReadInfo();
    }

    //将敌人数据存入词典
    void ReadInfo()
    {
        string text = Skill.text;                                    //将文本内容作为字符串读取
        string[] SkillArray = text.Split('\n');        //以\n为分割符将文本分割为一个数组
        foreach (string str in SkillArray)
        {
            SDic infoDic=new SDic();
            string[] skillStrings = str.Split(',');
            int id = Int32.Parse(skillStrings[0]);                    //技能ID
            string name = skillStrings[1];                            //技能名字
            int hurt = Int32.Parse(skillStrings[2]);                  //技能加血或者伤害
            int expend = int.Parse(skillStrings[3]);                  //升级效果
            int mp=Int32.Parse(skillStrings[4]);                      //技能消耗法力值
            float Continue = float.Parse(skillStrings[5]);            //持续效果
            int attribute = Int32.Parse(skillStrings[6]);             //增加属性
            string information = skillStrings[7];                     //技能介绍
            int type= Int32.Parse(skillStrings[8]);                   //获取技能类型

            infoDic.Id = id;
            infoDic.Name = name;
            infoDic.Hurt = hurt;
            infoDic.Expend = expend;
            infoDic.Mp = mp;
            infoDic.Continue = Continue;
            infoDic.Attribute = attribute;
            infoDic.Information = information;
            infoDic.Type = type;

            // 将物品信息存储到字典中
            skillDic.Add(id, infoDic);
        }
    }
}

//技能词典模板
public class SDic
{
    public int Id;                                                    //技能ID
    public string Name;                                               //技能名字
    public int Hurt;                                                  //技能伤害如果为医术类功法则加血
    public int Expend;                                                //升级花费
    public int Mp;                                                    //技能消耗法力值
    public float Continue;                                            //持续效果
    public int Attribute;                                             //增加属性
    public string Information;                                        //技能介绍

    //技能类型 1剑法 2刀法 3棍法 4暗器 5医术 6毒术
    public int Type;                                               
}