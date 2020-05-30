using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//游戏总控制器
public class GameManager : MonoBehaviour
{
    public Scrollbar ScrollbarVertical;                     //获取垂直滚动条

    public GameObject PlayerAttribute;                      //人物属性面板

    public GameObject PlayerSkill;                          //人物技能面板

    public GameObject PlayerBag;                            //人物背包

    public static bool CombatBool;                          //战斗是否能进入下一波

    public GameObject PlayerInfo;                           //获取角色信息面板

    public GameObject CombatGameObject;                     //获取战斗面板

    public GameObject EnemyPre;                             //获取敌人预制体

    public GameObject EnemyParent;                          //设置敌人父物体

    public GameObject InfoEnemy;                            //敌人信息

    public GameObject SignGameObject;                       //标记

    public GameObject SignGParent;                          //标记的父物体
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScrollbarRoll();
    }

    //始终保证滚动条在最下
    private void ScrollbarRoll()
    {
        if (ScrollbarVertical.value != 0)
        {
            if (ScrollbarVertical.value - 0.001f < 0)
            {
                ScrollbarVertical.value = 0;

            }
            else
            {
                ScrollbarVertical.value -= 0.001f;
            }
        }
    }

    //打开人物属性
    public void AttributeActivate()
    {
        PlayerAttribute.gameObject.SetActive(true);
        transform.GetComponent<Player>().ShowAttribute();
    }

    //打开技能界面
    public void SkillOpen()
    {
        PlayerSkill.gameObject.SetActive(true);
    }

    //打开背包界面
    public void BagOpen()
    {
        PlayerBag.gameObject.SetActive(true);
        PlayerBag.GetComponent<Bag>().All();
    }

    //进入战斗
    public IEnumerator CombatSystem(int[,] num)
    {
        CombatGameObject.gameObject.SetActive(true);
        transform.GetComponent<Player>().Show();
        for (int i = 0; i < num.GetLongLength(0); i++)
        {
            CombatBool = false;
            int index = 0;
            for (int j = 0; j < num.GetLongLength(1); j++)
            {
                if (num[i,j]>=0)
                {
                    index++;
                }
            }

            for (int j = 0; j < num.GetLongLength(1); j++)
            {
                if (num[i, j] != -1)
                {
                    GameObject obj = Instantiate(EnemyPre);
                    obj.GetComponent<Enemy>().Index = num[i, j];
                    obj.GetComponent<Enemy>().EnemyValue();
                    obj.GetComponent<Enemy>().Info = InfoEnemy;
                    obj.GetComponent<Enemy>().CombatGameObject = CombatGameObject;
                    obj.GetComponent<Enemy>().SignGameObject = SignGameObject;
                    obj.GetComponent<Enemy>().SignGParent = SignGParent;
                    obj.transform.SetParent(EnemyParent.transform);
                    if (index == 1)
                    {
                        obj.transform.localPosition = new Vector3(0, 280, 0);
                        obj.name = "2";
                    }
                    else if (index == 2)
                    {
                        if (j == 0)
                        {
                            obj.transform.localPosition = new Vector3(-150, 200, 0);
                            obj.name = "4";
                        }
                        else
                        {
                            obj.transform.localPosition = new Vector3(150, 200, 0);
                            obj.name = "6";
                        }
                    }
                    else if (index == 3)
                    {
                        if (j == 0)
                        {
                            obj.transform.localPosition = new Vector3(-150, 200, 0);
                            obj.name = "4";
                        }
                        else if (j == 1)
                        {
                            obj.transform.localPosition = new Vector3(150, 200, 0);
                            obj.name = "6";
                        }
                        else if (j == 2)
                        {
                            obj.transform.localPosition = new Vector3(0, 280, 0);
                            obj.name = "2";
                        }
                    }
                    else if (index == 4)
                    {
                        if (j == 0)
                        {
                            obj.transform.localPosition = new Vector3(-150, 280, 0);
                            obj.name = "1";
                        }
                        else if (j == 1)
                        {
                            obj.transform.localPosition = new Vector3(150, 280, 0);
                            obj.name = "3";
                        }
                        else if (j == 2)
                        {
                            obj.transform.localPosition = new Vector3(-150, 200, 0);
                            obj.name = "4";
                        }
                        else
                        {
                            obj.transform.localPosition = new Vector3(150, 200, 0);
                            obj.name = "6";
                        }
                    }
                    else if (index == 5)
                    {
                        if (j == 0)
                        {
                            obj.transform.localPosition = new Vector3(-150, 280, 0);
                            obj.name = "1";
                        }
                        else if (j == 1)
                        {
                            obj.transform.localPosition = new Vector3(150, 280, 0);
                            obj.name = "3";
                        }
                        else if (j == 2)
                        {
                            obj.transform.localPosition = new Vector3(-150, 200, 0);
                            obj.name = "4";
                        }
                        else if (j == 3)
                        {
                            obj.transform.localPosition = new Vector3(150, 200, 0);
                            obj.name = "6";
                        }
                        else
                        {
                            obj.transform.localPosition = new Vector3(0, 280, 0);
                            obj.name = "2";
                        }
                    }
                    else if (index == 6)
                    {
                        if (j == 0)
                        {
                            obj.transform.localPosition = new Vector3(-150, 280, 0);
                            obj.name = "1";
                        }
                        else if (j == 1)
                        {
                            obj.transform.localPosition = new Vector3(0, 280, 0);
                            obj.name = "2";
                        }
                        else if (j == 2)
                        {
                            obj.transform.localPosition = new Vector3(150, 280, 0);
                            obj.name = "3";
                        }
                        else if (j == 3)
                        {
                            obj.transform.localPosition = new Vector3(-150, 200, 0);
                            obj.name = "4";
                        }
                        else if (j == 4)
                        {
                            obj.transform.localPosition = new Vector3(0, 200, 0);
                            obj.name = "5";
                        }
                        else
                        {
                            obj.transform.localPosition = new Vector3(150, 200, 0);
                            obj.name = "6";
                        }
                    }
                }
            }

            StartCoroutine(CombatGameObject.GetComponent<Combat>().Sort(0));
            while (!CombatBool)
            {
                yield return 0;
            }
            CombatGameObject.gameObject.SetActive(false);
        }
    }
}
