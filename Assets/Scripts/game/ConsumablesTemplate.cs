using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//消耗品模板
[System.Serializable]
public class ConsumablesTemplate
{
    public int Id;

    public string Name;

    public int Num;                             //拥有的数量

    public int Hp;

    public int Mp;

    public int Exp;

    public string Information;

    public int Type;
}
