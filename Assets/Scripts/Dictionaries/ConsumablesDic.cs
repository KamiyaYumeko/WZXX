using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//消耗品词典
public class ConsumablesDic : MonoBehaviour
{
    public static Dictionary<int, ConD> consumablesDic
        = new Dictionary<int, ConD>();                              //申请字典

    public TextAsset Consumables;                                         //获取消耗品数据文本
    void Awake()
    {
        
    }

}

//消耗品词典模板
public class ConD
{

}