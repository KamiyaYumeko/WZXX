using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//开始游戏介绍
public class Introduce : MonoBehaviour
{
    public GameObject TextgGameObject;          //摧毁故事背景

    public Text T;                              //在信息框内生成介绍

    public TextAsset MTxt;                      //读取文本内容

    public GameObject PlayerInfo;               //显示角色信息界面

    public GameObject NPC;                      //显示NPC
    //看完介绍进入游戏
    public void GetInto()
    {
        T.text = "欢迎来到修仙世界";
        T.text += "\n"+ MTxt.text;
        PlayerInfo.gameObject.SetActive(true);
        NPC.gameObject.SetActive(true);
        Destroy(TextgGameObject);
        Destroy(transform.gameObject);
    }
}
