using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//物品
public class Equip : MonoBehaviour
{
    public int Index;                               //物品ID

    public int Type;                                //物品类型 1装备 2消耗品 3特殊

    public void ImgAndNum(int index,int num)
    {
        transform.GetComponentInChildren<Text>().text = ""+num;
        Sprite sprite = Resources.Load("", typeof(Sprite)) as Sprite;    //参数为资源路径和资源类型
        transform.GetComponent<Image>().sprite = sprite;
    }
}
