using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//管理背包
public class Bag : MonoBehaviour
{
    public GameObject Item;                     //物品预制体

    public GameObject ItemParent;               //设置物品父物体
    //显示全部装备
    public void All()
    {
        for (int i = 0; i < Player.EqList.Count; i++)
        {
            GameObject obj = Instantiate(Item);
            obj.transform.SetParent(ItemParent.transform);
            //TODO 装备赋值
        }
    }

    //剑
    public void Sword()
    {
        
    }

    //刀
    public void Knife()
    {

    }

    //棍
    public void Stick()
    {

    }

    //暗器
    public void Backstabber()
    {

    }

    //上衣
    public void Jacket()
    {

    }

    //裤子
    public void Trousers()
    {

    }

    //鞋子
    public void Shoe()
    {

    }

    //仙器
    public void XianQi()
    {

    }

    //消耗品
    public void Consumables()
    {

    }

    //特殊
    public void Special()
    {

    }
}
