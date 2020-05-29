using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//管理背包
public class Bag : MonoBehaviour
{
    public GameObject Item;                     //物品预制体

    public GameObject ItemParent;               //设置物品父物体

    //显示全部物品
    public void All()
    {
        Clear();
        foreach (var e in Player.EqList)
        {
            GameObject obj = Instantiate(Item);
            obj.transform.SetParent(ItemParent.transform);
            obj.GetComponent<Equip>().Index = e.Id;
            obj.GetComponent<Equip>().Type = 1;
        }

        foreach (var c in Player.ConList)
        {
            GameObject obj = Instantiate(Item);
            obj.transform.SetParent(ItemParent.transform);
            obj.GetComponent<Equip>().Index = c.Id;
            obj.GetComponent<Equip>().Type = 2;
        }

        foreach (var s in Player.SpeList)
        {
            GameObject obj = Instantiate(Item);
            obj.transform.SetParent(ItemParent.transform);
            obj.GetComponent<Equip>().Index = s.Id;
            obj.GetComponent<Equip>().Type = 3;
        }
    }

    //清空物品
    private void Clear()
    {
        for (int i = 0; i < ItemParent.transform.childCount; i++)
        {
            Destroy(ItemParent.transform.GetChild(i).gameObject);
        }
    }

    //筛选物品
    private void Select(int type)
    {
        foreach (var e in Player.EqList)
        {
            if (e.Type==type)
            {
                GameObject obj = Instantiate(Item);
                obj.transform.SetParent(ItemParent.transform);
                obj.GetComponent<Equip>().Index = e.Id;
                obj.GetComponent<Equip>().Type = 1;
            }
        }
    }

    //剑
    public void Sword()
    {
        Clear();
        Select(1);
    }

    //刀
    public void Knife()
    {
        Clear();
        Select(2);
    }

    //棍
    public void Stick()
    {
        Clear();
        Select(3);
    }

    //暗器
    public void Backstabber()
    {
        Clear();
        Select(4);
    }

    //上衣
    public void Jacket()
    {
        Clear();
        Select(5);
    }

    //裤子
    public void Trousers()
    {
        Clear();
        Select(6);
    }

    //鞋子
    public void Shoe()
    {
        Clear();
        Select(7);
    }

    //饰品
    public void Acc()
    {
        Clear();
        Select(8);
    }

    //仙器
    public void XianQi()
    {
        Clear();
        Select(9);
    }

    //消耗品
    public void Consumables()
    {
        Clear();
        foreach (var c in Player.ConList)
        {
            GameObject obj = Instantiate(Item);
            obj.transform.SetParent(ItemParent.transform);
            obj.GetComponent<Equip>().Index = c.Id;
            obj.GetComponent<Equip>().Type = 2;
        }
    }

    //特殊
    public void Special()
    {
        Clear();
        foreach (var s in Player.SpeList)
        {
            GameObject obj = Instantiate(Item);
            obj.transform.SetParent(ItemParent.transform);
            obj.GetComponent<Equip>().Index = s.Id;
            obj.GetComponent<Equip>().Type = 3;
        }
    }
}
