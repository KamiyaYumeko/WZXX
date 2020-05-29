using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//特殊品词典
public class SpecialDic : MonoBehaviour
{
    public static Dictionary<int, SpDic> specialDic
        = new Dictionary<int, SpDic>();                              //申请字典

    public TextAsset Special;                                        //获取装备数据文本

    void Awake()
    {
        ReadInfo();
    }

    void ReadInfo()
    {
        string text = Special.text;                                 // 将文本内容作为字符串读取
        string[] SpecialArray = text.Split('\n');     // 以\n为分割符将文本分割为一个数组
        foreach (string str in SpecialArray)
        {
            SpDic infoDic=new SpDic();
            string[] specialStrings = str.Split(',');
            int id = int.Parse(specialStrings[0]);                  //ID
            string name = specialStrings[1];                        //特殊品名字
            string Information = specialStrings[2];                 //装备介绍
            int Type = int.Parse(specialStrings[3]);                //装备类型

            infoDic.Id = id;
            infoDic.Name = name;
            infoDic.Information = Information;
            infoDic.Type = Type;

            specialDic.Add(id, infoDic);
        }
    }
}

//特殊品词典模板
public class SpDic
{
    public int Id;

    public string Name;

    public string Information;

    public int Type;
}
