using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//战斗系统管理
public class Combat : MonoBehaviour
{
    public GameObject AtcGameObject;                        //获取战斗按钮

    public GameObject SkillGameObject;                      //获取技能页面

    public GameObject SkillPref;                            //获取按钮预制体

    public GameObject SkillParent;                          //技能按钮设置父节点

    public static bool AtcBool;                             //攻击许可

    public static int Index;                                //获取攻击指令

    public List<GameObject> ListObjects;                    //获取所有的敌人和玩家

    public GameObject PlayerGameObject;                     //获取玩家

    public GameObject EnemyGameObject;                      //获取敌人

    public GameObject BlackButton;                          //返回按钮

    public GameObject SkillText;                            //获取技能介绍文本框
    // Start is called before the first frame update
    void Awake()
    {
        Index = -2;                                         //没有下达任何指令
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //点击攻击按钮
    public void AtcButton()
    {
        AtcGameObject.gameObject.SetActive(false);
        BlackButton.gameObject.SetActive(true);
        AtcBool = true;
        Index = -1;
    }

    //清空技能表
    private void ClearSkill()
    {
        for (int i = 0; i < SkillParent.transform.childCount; i++)
        {
            Destroy(SkillParent.transform.GetChild(i).gameObject);
        }
    }

    //点击技能按钮
    public void SkillButton()
    {
        AtcGameObject.gameObject.SetActive(false);
        SkillGameObject.gameObject.SetActive(true);
        BlackButton.gameObject.SetActive(true);
        ClearSkill();
        foreach (var s in Player.SkilList)
        {
            GameObject obj = Instantiate(SkillPref);
            obj.GetComponent<Skill>().Index = s.Id;
            obj.GetComponent<Skill>().SkillValue(s.Name);
            obj.GetComponent<Skill>().SkillText = SkillText;
            obj.GetComponent<Skill>().SkillGameObject = SkillGameObject;
            obj.GetComponent<Skill>().PlayerGameObject = PlayerGameObject;
            obj.GetComponent<Skill>().SkillUp = false;
            obj.transform.SetParent(SkillParent.transform);
        }
    }

    //点击防御按钮
    public void DefenseButton()
    {
        AtcGameObject.gameObject.SetActive(false);
    }

    //点击逃跑按钮
    public void FleeButton()
    {
        AtcGameObject.gameObject.SetActive(false);
    }

    //返回按钮
    public void RetButton()
    {
        AtcGameObject.gameObject.SetActive(true);
        SkillGameObject.gameObject.SetActive(false);
        BlackButton.gameObject.SetActive(false);
        Index = -2;
    }

    //出招排序
    public IEnumerator Sort(int time)
    {
        yield return new WaitForSeconds(time);
        if (ListObjects.Count == 0)
        {
            ListObjects.Add(PlayerGameObject);
            for (int i = 0; i < EnemyGameObject.transform.childCount; i++)
            {
                ListObjects.Add(EnemyGameObject.transform.GetChild(i).gameObject);
            }
        }

        //移除死亡敌人
        for (int i = ListObjects.Count-1; i >=0 ; i--)
        {
            if (ListObjects[i] != PlayerGameObject)
            {
                if (ListObjects[i])
                {
                    if (ListObjects[i].GetComponent<Enemy>().Death)
                    {
                        ListObjects.RemoveAt(i);
                    }
                }
                else
                {
                    ListObjects.RemoveAt(i);
                }
            }
        }

        //判断敌人是否全部死亡
        if (ListObjects.Count == 0)
        {
            GameManager.CombatBool = true;
        }
        else if (ListObjects.Count == 1&& ListObjects[0]== PlayerGameObject)
        {
            GameManager.CombatBool = true;
        }
        else
        {
            GameObject obj = ListObjects[0];
            int num;
            int index = 0;
            if (obj == PlayerGameObject)
            {
                num = ListObjects[0].GetComponent<Player>().PlayerAttribute.Speed;
            }
            else
            {
                num = ListObjects[0].GetComponent<Enemy>().EnemyAttribute.Speed;
            }

            for (int i = 1; i < ListObjects.Count; i++)
            {
                if (num < ListObjects[i].GetComponent<Enemy>().EnemyAttribute.Speed)
                {
                    num = ListObjects[i].GetComponent<Enemy>().EnemyAttribute.Speed;
                    obj = ListObjects[i];
                    index = i;
                }
            }

            if (obj == PlayerGameObject)
            {
                Player.ActionBool = true;
                AtcGameObject.gameObject.SetActive(true);
                ListObjects.RemoveAt(index);
            }
            else
            {
                StartCoroutine(ListObjects[index].GetComponent<Enemy>().Action());
                ListObjects.RemoveAt(index);
            }
        }

    }

    //开始标记
    public void Sign(int num)
    {
        if (Index!=-2)
        {
            List<GameObject> objects=new List<GameObject>();
            for (int i = 0; i < EnemyGameObject.transform.childCount; i++)
            {
                objects.Add(EnemyGameObject.transform.GetChild(i).gameObject);
            }
            if (Index==-1)
            {
                foreach (var v in objects)
                {
                    if (v.name==""+num)
                    {
                        v.GetComponent<Enemy>().Sign();
                    }
                }
            }
            else
            {
                if (Player.SkilList[Index].Type != 5)
                {
                    if (Player.SkilList[Index].Type.Equals(1))
                    {
                        if (num <= 3)
                        {
                            foreach (var v in objects)
                            {
                                if (v.name == "" + num || v.name == "" + (num + 3))
                                {
                                    v.GetComponent<Enemy>().Sign();
                                }
                            }
                        }
                        else
                        {
                            foreach (var v in objects)
                            {
                                if (v.name == "" + num || v.name == "" + (num - 3))
                                {
                                    v.GetComponent<Enemy>().Sign();
                                }
                            }
                        }
                    }
                    else if (Player.SkilList[Index].Type == 2)
                    {
                        if (num <= 3)
                        {
                            foreach (var v in objects)
                            {
                                for (int i = 1; i < 4; i++)
                                {
                                    if (v.name == "" + i)
                                    {
                                        v.GetComponent<Enemy>().Sign();
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (var v in objects)
                            {
                                for (int i = 4; i < 7; i++)
                                {
                                    if (v.name == "" + i)
                                    {
                                        v.GetComponent<Enemy>().Sign();
                                    }
                                }
                            }
                        }
                    }
                    else if (Player.SkilList[Index].Type == 3)
                    {
                        foreach (var v in objects)
                        {
                            v.GetComponent<Enemy>().Sign();
                        }
                    }
                }
            }
        }
    }

    //攻击敌人
    public void AtcEnemy(int num)
    {
        if (Index != -2)
        {
            List<GameObject> objects = new List<GameObject>();
            for (int i = 0; i < EnemyGameObject.transform.childCount; i++)
            {
                objects.Add(EnemyGameObject.transform.GetChild(i).gameObject);
            }
            if (Index == -1)
            {
                foreach (var v in objects)
                {
                    if (v.name == "" + num)
                    {
                        v.GetComponent<Enemy>().TriggerHarm();
                    }
                }
            }
            else
            {
                if (Player.SkilList[Index].Type != 5)
                {
                    if (Player.SkilList[Index].Type.Equals(1))
                    {
                        if (num <= 3)
                        {
                            foreach (var v in objects)
                            {
                                if (v.name == "" + num || v.name == "" + (num + 3))
                                {
                                    v.GetComponent<Enemy>().TriggerHarm();
                                }
                            }
                        }
                        else
                        {
                            foreach (var v in objects)
                            {
                                if (v.name == "" + num || v.name == "" + (num - 3))
                                {
                                    v.GetComponent<Enemy>().TriggerHarm();
                                }
                            }
                        }
                    }
                    else if (Player.SkilList[Index].Type == 2)
                    {
                        if (num <= 3)
                        {
                            foreach (var v in objects)
                            {
                                for (int i = 1; i < 4; i++)
                                {
                                    if (v.name == "" + i)
                                    {
                                        v.GetComponent<Enemy>().TriggerHarm();
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (var v in objects)
                            {
                                for (int i = 4; i < 7; i++)
                                {
                                    if (v.name == "" + i)
                                    {
                                        v.GetComponent<Enemy>().TriggerHarm();
                                    }
                                }
                            }
                        }
                    }
                    else if (Player.SkilList[Index].Type == 3)
                    {
                        foreach (var v in objects)
                        {
                            v.GetComponent<Enemy>().TriggerHarm();
                        }
                    }
                }
            }
        }
        BlackButton.gameObject.SetActive(false);
        StartCoroutine(Sort(2));
    }
}
