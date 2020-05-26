using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//消耗品词典
public class ConsumablesDic : MonoBehaviour
{
    public static Dictionary<int, ConDic> consumablesDic
        = new Dictionary<int, ConDic>(); //申请字典

    public TextAsset Consumables; //获取消耗品数据文本

    void Awake()
    {
        ReadInfo();
    }

    //将消耗品数据存入字典
    void ReadInfo()
    {
        string text = Consumables.text;                             // 将文本内容作为字符串读取
        string[] ConsumablesArray = text.Split('\n'); // 以\n为分割符将文本分割为一个数组
        foreach (string str in ConsumablesArray)
        {
            ConDic infoDic = new ConDic();
            string[] equipStrings = str.Split(',');
            int id = Int32.Parse(equipStrings[0]);                  //消耗品ID
            string name = equipStrings[1];                          //消耗品名称
            int hp = Int32.Parse(equipStrings[2]);                  //增加hp
            int mp = Int32.Parse(equipStrings[3]);                  //增加mp
            int exp = Int32.Parse(equipStrings[4]);                 //增加经验值
            string Information = equipStrings[5];                   //介绍
            int type=Int32.Parse(equipStrings[6]);                  //消耗品类型

            infoDic.Id = id;
            infoDic.Name = name;
            infoDic.Hp = hp;
            infoDic.Mp = mp;
            infoDic.Exp = exp;
            infoDic.Information = Information;
            infoDic.Type = type;
            consumablesDic.Add(id, infoDic);
        }
    }
}

//消耗品词典模板
public class ConDic
{
    public int Id;

    public string Name;

    public int Hp;

    public int Mp;

    public int Exp;

    public string Information;

    public int Type;
}