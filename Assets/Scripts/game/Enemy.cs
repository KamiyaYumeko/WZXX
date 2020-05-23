using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;


//敌人数据
public class Enemy : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public int Index;                                   //获取敌人编号

    public Attribute EnemyAttribute;                    //创建敌人模板

    private List<SkillTemplate> SkilList;               //获取技能

    private Text _tText;                                //在信息框内显示信息

    private GameObject _player;                         //获取玩家

    public GameObject Info;                             //敌人信息

    public GameObject CombatGameObject;                 //获取战斗脚本

    public bool Death;                                  //该敌人是否死亡

    public GameObject SignGameObject;                   //标记

    public GameObject SignGParent;                      //标记的父物体

    void Awake()
    {
        _tText = GameObject.Find("信息框")
            .transform.GetChild(0).GetChild(0).GetComponent<Text>();
        _player = GameObject.Find("GameManager");
        SkilList = new List<SkillTemplate>();
        Death = false;
    }

    //给敌人赋值
    public void EnemyValue()
    {
        EnemyAttribute.Strength = EnemyDic.enemyDic[Index].Strength;
        EnemyAttribute.Agility = EnemyDic.enemyDic[Index].Agility;
        EnemyAttribute.Neili = EnemyDic.enemyDic[Index].Neili;
        EnemyAttribute.Atk = EnemyDic.enemyDic[Index].Atk;
        EnemyAttribute.Speed = EnemyDic.enemyDic[Index].Speed;
        EnemyAttribute.Dodge = EnemyDic.enemyDic[Index].Dodge;
        EnemyAttribute.Armor = EnemyDic.enemyDic[Index].Armor;
        EnemyAttribute.Magic = EnemyDic.enemyDic[Index].Magic;
        EnemyAttribute.MaxHp = EnemyDic.enemyDic[Index].MaxHp;
        EnemyAttribute.Hp = EnemyDic.enemyDic[Index].MaxHp;
        EnemyAttribute.HpBack = EnemyDic.enemyDic[Index].HpBack;
        EnemyAttribute.MaxMp = EnemyDic.enemyDic[Index].MaxMp;
        EnemyAttribute.Mp = EnemyDic.enemyDic[Index].MaxMp;
        EnemyAttribute.MpBack = EnemyDic.enemyDic[Index].MpBack;
        EnemyAttribute.Sword = EnemyDic.enemyDic[Index].Sword;
        EnemyAttribute.Knife = EnemyDic.enemyDic[Index].Knife;
        EnemyAttribute.Stick = EnemyDic.enemyDic[Index].Stick;
        EnemyAttribute.Backstabber = EnemyDic.enemyDic[Index].Backstabber;
        EnemyAttribute.Leechcraft = EnemyDic.enemyDic[Index].Leechcraft;
        EnemyAttribute.Poisoning = EnemyDic.enemyDic[Index].Poisoning;
        EnemyAttribute.Lv = EnemyDic.enemyDic[Index].Lv;
        transform.GetComponentInChildren<Text>().text= EnemyDic.enemyDic[Index].Name;

        for (int i = 0; i < EnemyDic.enemyDic[Index].SkillInts.Count; i++)
        {
            Skill(EnemyDic.enemyDic[Index].SkillInts[i], EnemyDic.enemyDic[Index].Lv);
        }
    }

    //获得技能给技能赋值
    private void Skill(int index, int lv)
    {
        SkillTemplate SkillT = new SkillTemplate();
        SkillT.Id = SkillDic.skillDic[index].Id;
        SkillT.Name = SkillDic.skillDic[index].Name;
        SkillT.Lv = lv;
        SkillT.Hurt = SkillDic.skillDic[index].Hurt*lv;
        SkillT.Expend = SkillDic.skillDic[index].Expend;
        SkillT.Mp = SkillDic.skillDic[index].Mp*lv;
        SkillT.Continue = SkillDic.skillDic[index].Continue;
        SkillT.Attribute = SkillDic.skillDic[index].Attribute;
        SkillT.Information = SkillDic.skillDic[index].Information;
        SkillT.Type = SkillDic.skillDic[index].Type;
        SkilList.Add(SkillT);
    }

    //伤害结算
    public IEnumerator HarmClearing(int harm)
    {
        for (int i = 0; i < SignGParent.transform.childCount; i++)
        {
            Destroy(SignGParent.transform.GetChild(i).gameObject);
        }

        if (harm >= EnemyAttribute.Hp)
        {
            Death = true;
        }
        for (int i = 0; i < harm; i++)
        {
            EnemyAttribute.Hp--;
            InfoEnemy();
            if (EnemyAttribute.Hp<=0)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(0.05f);
        }
        Combat.Index = -2;
    }

    //敌人动作
    public IEnumerator Action()
    {
        InfoEnemy();
        Vector3 Vec = gameObject.transform.localPosition;
        List<int> list = new List<int>();
        for (int i = 0; i < SkilList.Count; i++)
        {
            if (EnemyAttribute.Mp > SkilList[i].Mp)
            {
                list.Add(i);
            }
        }
        for (int i = 0; i < 50; i++)
        {
            transform.Translate(Vector3.down);
            yield return new WaitForSeconds(0.01f);
        }
        if (list.Count>0)
        {
            if (Random.Range(1, 100) < 50)                      //普通攻击
            {
                int harm = EnemyAttribute.Atk -
                           _player.GetComponent<Player>().PlayerAttribute.Armor;
                if (harm < 1)
                {
                    harm = 1;
                }
                StartCoroutine(_player.GetComponent<Player>().HarmClearing(harm));

                _tText.text += "\n" + "敌人对你使用了普通攻击造成" + harm + "点伤害";
            }
            else                                                //技能
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (Random.Range(1, 100) < 100 - (list.Count - i - 1) * (50 / list.Count))
                    {
                        if (SkilList[list[i]].Type != 5)
                        {
                            int type = 0;
                            if (SkilList[list[i]].Type == 1)
                            {
                                type = EnemyAttribute.Sword;
                            }
                            else if (SkilList[list[i]].Type == 2)
                            {
                                type = EnemyAttribute.Knife;
                            }
                            else if (SkilList[list[i]].Type == 3)
                            {
                                type = EnemyAttribute.Stick;
                            }
                            else if (SkilList[list[i]].Type == 4)
                            {
                                type = EnemyAttribute.Backstabber;
                            }
                            else if (SkilList[list[i]].Type == 6)
                            {
                                type = EnemyAttribute.Poisoning;
                            }

                            SkillClearingE(SkilList[list[i]].Mp, SkilList[list[i]].Hurt, type,
                                SkilList[list[i]].Name);
                            break;
                        }
                        else
                        {
                            //TODO 使用医术
                        }
                    }
                }
            }
        }
        else
        {
            int harm = EnemyAttribute.Atk -
                       _player.GetComponent<Player>().PlayerAttribute.Armor;
            if (harm < 1)
            {
                harm = 1;
            }
            StartCoroutine(_player.GetComponent<Player>().HarmClearing(harm));

            _tText.text += "\n" + "敌人对你使用了普通攻击造成" + harm + "点伤害";
        }
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localPosition = Vec;
    }

    //技能伤害结算敌人使用
    /// <summary>
    /// 耗蓝
    /// 技能基础伤害
    /// 技能类型伤害
    /// </summary>
    /// <param name="mp"></param>
    /// <param name="hurt"></param>
    /// <param name="type"></param>
    private void SkillClearingE(int mp,int hurt,int type,string name)
    {
        EnemyAttribute.Mp -= mp;
        int harm = (int)((hurt + type) *
                         (1 + EnemyAttribute.Magic)) - _player.GetComponent<Player>()
            .PlayerAttribute.Armor;
        if (harm < 1)
        {
            harm = 1;
        }

        StartCoroutine(_player.GetComponent<Player>().HarmClearing(harm));
        _tText.text += "\n" + EnemyDic.enemyDic[Index].Name + "对你使用了" + name + "造成" + harm + "点伤害";
    }

    //显示敌人信息
    public void InfoEnemy()
    {
        Info.gameObject.SetActive(true);

        Info.transform.GetChild(1).GetChild(1).GetComponent<Image>().fillAmount =
            EnemyAttribute.Hp / EnemyAttribute.MaxHp;

        Info.transform.GetChild(1).GetChild(2).GetComponent<Text>().text =
            EnemyAttribute.Hp + "/" + EnemyAttribute.MaxHp;

        Info.transform.GetChild(2).GetChild(1).GetComponent<Image>().fillAmount =
            EnemyAttribute.Mp / EnemyAttribute.MaxMp;

        Info.transform.GetChild(2).GetChild(2).GetComponent<Text>().text =
            EnemyAttribute.Mp + "/" + EnemyAttribute.MaxMp;
    }

    //点击敌人进行攻击
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Combat.AtcBool)
        {
            CombatGameObject.GetComponent<Combat>().AtcEnemy(Int32.Parse(transform.name));
        }
    }

    //触发伤害
    public void TriggerHarm()
    {
        Combat.AtcBool = false;
        if (Combat.Index >= 0)
        {
            if (Player.SkilList[Combat.Index].Type != 5)
            {
                int type=0;
                if (Player.SkilList[Combat.Index].Type==1)
                {
                    type = _player.GetComponent<Player>().PlayerAttribute.Sword;
                }
                else if (Player.SkilList[Combat.Index].Type == 2)
                {
                    type = _player.GetComponent<Player>().PlayerAttribute.Knife;
                }
                else if (Player.SkilList[Combat.Index].Type == 3)
                {
                    type = _player.GetComponent<Player>().PlayerAttribute.Stick;
                }
                else if (Player.SkilList[Combat.Index].Type == 4)
                {
                    type = _player.GetComponent<Player>().PlayerAttribute.Backstabber;
                }
                else if (Player.SkilList[Combat.Index].Type == 6)
                {
                    type = _player.GetComponent<Player>().PlayerAttribute.Poisoning;
                }
                SkillClearingP(Player.SkilList[Combat.Index].Mp, Player.SkilList[Combat.Index].Hurt, type,
                    Player.SkilList[Combat.Index].Name);
            }
            else
            {
                _tText.text += "\n" + "该技能无法对敌人使用";
            }
        }
        else
        {
            int harm = _player.GetComponent<Player>().PlayerAttribute.Atk
                       - EnemyAttribute.Armor;
            if (harm < 1)
            {
                harm = 1;
            }
            StartCoroutine(HarmClearing(harm));
            _tText.text += "\n" + "你对敌人使用普通攻击造成" + harm + "点伤害";
            Player.ActionBool = false;
        }
    }

    //技能伤害结算玩家使用
    /// <summary>
    /// 耗蓝
    /// 技能基础伤害
    /// 技能类型伤害
    /// </summary>
    /// <param name="mp"></param>
    /// <param name="hurt"></param>
    /// <param name="type"></param>
    private void SkillClearingP(int mp, int hurt, int type, string name)
    {
        _player.GetComponent<Player>().PlayerAttribute.Mp -= mp;
        int harm = (int)((hurt + type) *
                         (1 + _player.GetComponent<Player>().PlayerAttribute.Magic)) - EnemyAttribute.Armor;
        if (harm < 1)
        {
            harm = 1;
        }

        StartCoroutine(HarmClearing(harm));
        _tText.text += "\n" + "你对"+EnemyDic.enemyDic[Index].Name+"使用了" + name + "造成" + harm + "点伤害";
    }

    //生成标记
    public void Sign()
    {
        GameObject obj = Instantiate(SignGameObject);
        obj.transform.SetParent(SignGParent.transform);
        obj.transform.localPosition = transform.localPosition;
    }

    //鼠标放在敌人上
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Player.ActionBool)
        {
            InfoEnemy();
        }

        if (Combat.AtcBool)
        {
            CombatGameObject.GetComponent<Combat>().Sign(Int32.Parse(transform.name));
        }
    }

    //鼠标离开敌人
    public void OnPointerExit(PointerEventData eventData)
    {
        if (Player.ActionBool)
        {
            Info.gameObject.SetActive(false);
        }

        if (Combat.AtcBool)
        {
            for (int i = 0; i < SignGParent.transform.childCount; i++)
            {
                Destroy(SignGParent.transform.GetChild(i).gameObject);
            }
        }
    }
}
