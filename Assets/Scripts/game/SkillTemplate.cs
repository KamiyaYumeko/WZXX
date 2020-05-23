using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//技能模板
[System.Serializable]
public class SkillTemplate
{
    public int Id;                                      //技能编号
    public string Name;                                 //技能名字
    public int Lv;                                      //技能等级
    public int Hurt;                                    //技能伤害或治疗
    public int Expend;                                  //升级花费
    public int Mp;                                      //技能消耗法力值
    public float Continue;                              //持续效果
    public int Attribute;                               //增加属性
    public string Information;                          //技能介绍
    public int Type;                                    //技能类型
}
