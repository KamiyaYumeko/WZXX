using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

//玩家属性
public class Player : MonoBehaviour
{
    public Attribute PlayerAttribute;                   //调用属性模板

    public Text ExpText;                                //显示经验值

    public Image ExpImage;                              //经验条图片

    public Text[] AttributeTexts;                       //在属性面板显示属性

    public static List<SkillTemplate> SkilList;         //学习技能

    public static List<GFTemplate> GfList;              //学习功法

    public static List<EquipTemplate> EqList;           //获得装备

    public static List<ConsumablesTemplate> ConList;    //获得消耗品

    public static List<SpecialTemplate> SpeList;        //获得特殊物品

    public GameObject PlayerInfo;                       //获取战斗界面玩家信息

    public Text T;                                      //在信息框内生成信息

    public static bool ActionBool;                      //允许行动

    public GameObject CombatGameObject;                 //获取战斗脚本 

    public static int Sp;                               //升级技能值

    //测试
    private int tt;
    void Awake()
    {
        SkilList=new List<SkillTemplate>();
        GfList=new List<GFTemplate>();
        EqList=new List<EquipTemplate>();
        ConList=new List<ConsumablesTemplate>();
        SpeList=new List<SpecialTemplate>();
        Assignment();
    }

    // Update is called once per frame
    void Update()
    {
        //测试
        tt++;
        if (tt>=100)
        {
            tt = -1000000;
            Skill(0, 1);
            Skill(1, 1);
            Skill(2, 1);
            Skill(3, 1);
            Gf(0, 1);
        }
    }

    //玩家属性赋值
    private void Assignment()
    {
        PlayerAttribute.Strength = Random.Range(10,15);
        PlayerAttribute.Agility = Random.Range(10, 15);
        PlayerAttribute.Neili = Random.Range(10, 15);


        PlayerAttribute.Armor = 0;
        PlayerAttribute.HpBack = 0;
        PlayerAttribute.MpBack = 0;
        PlayerAttribute.Sword = 0;
        PlayerAttribute.Knife = 0;
        PlayerAttribute.Stick = 0;
        PlayerAttribute.Backstabber = 0;
        PlayerAttribute.Leechcraft = 0;
        PlayerAttribute.Poisoning = 0;
        PlayerAttribute.Lv = 1;
        PlayerAttribute.Exp = 0;
        Sp = 0;
        PlayerAttribute.MaxExp = Mathf.Pow(PlayerAttribute.Lv - 1, 3) * 60 + 60;


        PlayerAttribute.Atk = Random.Range(10, 15)+ PlayerAttribute.Strength;
        PlayerAttribute.Speed = Random.Range(10, 15) + PlayerAttribute.Agility;
        PlayerAttribute.Dodge = 0 + PlayerAttribute.Agility / 100;
        PlayerAttribute.Magic = 0 + PlayerAttribute.Neili / 100;
        PlayerAttribute.MaxHp = Random.Range(200, 250) + PlayerAttribute.Strength * 5;
        PlayerAttribute.Hp = PlayerAttribute.MaxHp;
        PlayerAttribute.MaxMp = Random.Range(100, 150) + PlayerAttribute.Neili * 10;
        PlayerAttribute.Mp = PlayerAttribute.MaxMp;

        ExpText.text = "" + PlayerAttribute.Exp + "/" + PlayerAttribute.MaxExp;
        ExpImage.fillAmount = PlayerAttribute.Exp / PlayerAttribute.MaxExp;
    }

    //用协程显示增加经验值动画
    public IEnumerator Increase(float num)
    {
        for (int i = 0; i < num; i++)
        {
            if (PlayerAttribute.Exp++> PlayerAttribute.MaxExp)
            {
                PlayerAttribute.Exp = 0;
                PlayerAttribute.MaxExp = Mathf.Pow(PlayerAttribute.Lv - 1, 3) * 60 + 60;
                
                //TODO 升级属性加成
            }
            else
            {
                PlayerAttribute.Exp++;
                yield return new WaitForSeconds(1);
            }

            ExpText.text = "" + PlayerAttribute.Exp + "/" + PlayerAttribute.MaxExp;
            ExpImage.fillAmount = PlayerAttribute.Exp / PlayerAttribute.MaxExp;
        }
    }

    //在属性面板显示属性
    public void ShowAttribute()
    {
        AttributeTexts[0].text = "力量：" + PlayerAttribute.Strength;
        AttributeTexts[1].text = "敏捷：" + PlayerAttribute.Agility;
        AttributeTexts[2].text = "内力：" + PlayerAttribute.Neili;
        AttributeTexts[3].text = "攻击力：" + PlayerAttribute.Atk;
        AttributeTexts[4].text = "速度：" + PlayerAttribute.Speed;
        AttributeTexts[5].text = "闪避：" + PlayerAttribute.Dodge*100+"%";
        AttributeTexts[6].text = "护甲：" + PlayerAttribute.Armor;
        AttributeTexts[7].text = "法术增强：" + PlayerAttribute.Magic * 100 + "%";
        AttributeTexts[8].text = "生命值：" + 
            PlayerAttribute.Hp + "/" + PlayerAttribute.MaxHp;
        AttributeTexts[9].text = "生命恢复：" + PlayerAttribute.HpBack;
        AttributeTexts[10].text = "法力值：" + 
            PlayerAttribute.Mp+"/"+ PlayerAttribute.MaxMp;
        AttributeTexts[11].text = "法力值恢复：" + PlayerAttribute.MpBack;
        AttributeTexts[12].text = "剑法：" + PlayerAttribute.Sword;
        AttributeTexts[13].text = "刀法：" + PlayerAttribute.Knife;
        AttributeTexts[14].text = "棍法：" + PlayerAttribute.Stick;
        AttributeTexts[15].text = "暗器：" + PlayerAttribute.Backstabber;
        AttributeTexts[16].text = "医术：" + PlayerAttribute.Leechcraft;
        AttributeTexts[17].text = "毒术：" + PlayerAttribute.Poisoning;
    }

    //获得技能给技能赋值
    public void Skill(int index,int lv)
    {
        if (Skill(index))
        {
            SkillTemplate SkillT = new SkillTemplate
            {
                Id = SkillDic.skillDic[index].Id,
                Name = SkillDic.skillDic[index].Name,
                Lv = lv,
                Hurt = SkillDic.skillDic[index].Hurt * lv,
                Expend = SkillDic.skillDic[index].Expend,
                Mp = SkillDic.skillDic[index].Mp,
                Continue = SkillDic.skillDic[index].Continue,
                Attribute = SkillDic.skillDic[index].Attribute * lv,
                Information = SkillDic.skillDic[index].Information,
                Type = SkillDic.skillDic[index].Type
            };
            SkilList.Add(SkillT);
            AddAttribute(SkillT.Attribute, SkillT.Type);
            T.text += "\n" + SkillDic.skillDic[index].Name
                           + "技能学习成功";
        }
        else
        {
            T.text += "\n" + SkillDic.skillDic[index].Name 
                           + "技能已经学习过，无法重复学习";
        }
    }

    //判断技能是否已经学习
    public bool Skill(int index)
    {
        if (SkilList.Count>0)
        {
            foreach (var s in SkilList)
            {
                if (s.Id == SkillDic.skillDic[index].Id)
                {
                    return false;
                }
            }
        }
        
        return true;
    }

    //技能增加属性
    public void AddAttribute(int att,int type)
    {
        switch (type)
        {
            case 1:
                PlayerAttribute.Sword += att;
                break;
            case 2:
                PlayerAttribute.Knife += att;
                break;
            case 3:
                PlayerAttribute.Stick += att;
                break;
            case 4:
                PlayerAttribute.Backstabber += att;
                break;
            case 5:
                PlayerAttribute.Leechcraft += att;
                break;
            case 6:
                PlayerAttribute.Poisoning += att;
                break;
        }
    }

    //获得功法
    public void Gf(int index, int lv)
    {
        if (Gf(index))
        {
            GFTemplate GfT = new GFTemplate
            {
                Id = GongFaDic.GongfDic[index].Id,
                Name = GongFaDic.GongfDic[index].Name,
                Lv = lv,
                Strength = GongFaDic.GongfDic[index].Strength * lv,
                Agility = GongFaDic.GongfDic[index].Agility * lv,
                Neili = GongFaDic.GongfDic[index].Neili * lv,
                Atk = GongFaDic.GongfDic[index].Atk * lv,
                Speed = GongFaDic.GongfDic[index].Speed * lv,
                Dodge = GongFaDic.GongfDic[index].Dodge * lv,
                Armor = GongFaDic.GongfDic[index].Armor * lv,
                Magic = GongFaDic.GongfDic[index].Magic * lv,
                MaxHp = GongFaDic.GongfDic[index].MaxHp * lv,
                HpBack = GongFaDic.GongfDic[index].HpBack * lv,
                MaxMp = GongFaDic.GongfDic[index].MaxMp * lv,
                MpBack = GongFaDic.GongfDic[index].MpBack * lv,
                Information = GongFaDic.GongfDic[index].Information
            };
            GfList.Add(GfT);

            AddAttribute(GfT.Strength, GfT.Agility, GfT.Neili,
                GfT.Atk, GfT.Speed, GfT.Dodge, GfT.Armor, GfT.Magic,
                GfT.MaxHp, GfT.MaxHp, GfT.HpBack, GfT.MaxMp,
                GfT.MaxMp,GfT.MpBack);
            T.text += "\n" + GongFaDic.GongfDic[index].Name
                           + "功法学习成功";
        }
        else
        {
            T.text += "\n" + GongFaDic.GongfDic[index].Name
                           + "功法已经学习过，无法重复学习";
        }
    }

    //判断功法是否学习
    public bool Gf(int index)
    {
        if (GfList.Count > 0)
        {
            foreach (var G in GfList)
            {
                if (G.Id == GongFaDic.GongfDic[index].Id)
                {
                    return false;
                }
            }
        }

        return true;
    }

    //功法增加属性
    public void AddAttribute(int strength, int agility, 
        int neili, int atk, int speed, float dodge, int armor, 
        float magic, float maxHp, float hp, float hpBack, 
        float maxMp, float mp, float mpBack)
    {
        PlayerAttribute.Strength += strength;
        PlayerAttribute.Agility += agility;
        PlayerAttribute.Neili += neili;
        PlayerAttribute.Atk += atk;
        PlayerAttribute.Speed = speed;
        PlayerAttribute.Dodge = dodge;
        PlayerAttribute.Armor = armor;
        PlayerAttribute.Magic = magic;
        PlayerAttribute.MaxHp = maxHp;
        PlayerAttribute.Hp = hp;
        PlayerAttribute.HpBack = hpBack;
        PlayerAttribute.MaxMp = maxMp;
        PlayerAttribute.Mp = mp;
        PlayerAttribute.MpBack = mpBack;
    }

    //获得装备
    public void AddEq(int index, int lv)
    {
        EquipTemplate eqT = new EquipTemplate
        {
            Id = EquipDic.equipDic[index].Id,
            Name = EquipDic.equipDic[index].Name,
            Lv = lv,
            Strength = EquipDic.equipDic[index].Strength * lv,
            Agility = EquipDic.equipDic[index].Agility * lv,
            Neili = EquipDic.equipDic[index].Neili * lv,
            Atk = EquipDic.equipDic[index].Atk * lv,
            Speed = EquipDic.equipDic[index].Speed * lv,
            Dodge = EquipDic.equipDic[index].Dodge * lv,
            Armor = EquipDic.equipDic[index].Armor * lv,
            Magic = EquipDic.equipDic[index].Magic * lv,
            MaxHp = EquipDic.equipDic[index].MaxHp * lv,
            HpBack = EquipDic.equipDic[index].HpBack * lv,
            MaxMp = EquipDic.equipDic[index].MaxMp * lv,
            MpBack = EquipDic.equipDic[index].MpBack * lv,
            Sword = EquipDic.equipDic[index].Sword * lv,
            Knife = EquipDic.equipDic[index].Knife * lv,
            Stick = EquipDic.equipDic[index].Stick * lv,
            Backstabber = EquipDic.equipDic[index].Backstabber * lv,
            Leechcraft = EquipDic.equipDic[index].Leechcraft * lv,
            Poisoning = EquipDic.equipDic[index].Poisoning * lv,
            Information = EquipDic.equipDic[index].Information,
            Type = EquipDic.equipDic[index].Type
        };
        EqList.Add(eqT);
    }

    //获得消耗品
    public void AddCon(int index,int num)
    {
        if (Con(index,num))
        {
            ConsumablesTemplate conTe = new ConsumablesTemplate
            {
                Id = ConsumablesDic.consumablesDic[index].Id,
                Name = ConsumablesDic.consumablesDic[index].Name,
                Num = num,
                Hp = ConsumablesDic.consumablesDic[index].Hp,
                Mp = ConsumablesDic.consumablesDic[index].Mp,
                Exp = ConsumablesDic.consumablesDic[index].Exp,
                Information = ConsumablesDic.consumablesDic[index].Information,
                Type = ConsumablesDic.consumablesDic[index].Type
            };
            ConList.Add(conTe);
        }

        T.text += "\n" + "获得" + ConsumablesDic.consumablesDic[index].Name
                  + "X" + num;
    }

    //判断是否已拥有 
    //TODO 该地方可能会出现BUG注意
    public bool Con(int index,int num)
    {
        if (ConList.Count>0)
        {
            foreach (var c in ConList)
            {
                if (ConList[index].Num==99)
                {
                    return true;
                }
                else
                {
                    if (c.Id == ConsumablesDic.consumablesDic[index].Id)
                    {
                        c.Num += num;
                        return false;
                    }
                }
            }
        }
        return true;
    }

    //获得特殊品
    public void AddSpe(int index)
    {
        SpecialTemplate speTe = new SpecialTemplate
        {
            Id = SpecialDic.specialDic[index].Id,
            Name = SpecialDic.specialDic[index].Name,
            Information = SpecialDic.specialDic[index].Information,
            Type = SpecialDic.specialDic[index].Type
        };
        SpeList.Add(speTe);
        T.text += "\n" + "获得" + SpecialDic.specialDic[index].Name;
    }

    //伤害结算
    public IEnumerator HarmClearing(int harm)
    {
        for (int i = 0; i < harm; i++)
        {
            PlayerAttribute.Hp--;
            Show();
            if (PlayerAttribute.Hp <= 0)
            {
                //TODO 失败
            }
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(CombatGameObject.GetComponent<Combat>().Sort(1));
        Combat.Index = -2;
    }

    //战斗界面显示信息
    public void Show()
    {
        PlayerInfo.transform.GetChild(0).GetChild(1).GetComponent<Image>().fillAmount =
            PlayerAttribute.Hp / PlayerAttribute.MaxHp;

        PlayerInfo.transform.GetChild(0).GetChild(2).GetComponent<Text>().text =
            PlayerAttribute.Hp + "/" + PlayerAttribute.MaxHp;

        PlayerInfo.transform.GetChild(1).GetChild(1).GetComponent<Image>().fillAmount =
            PlayerAttribute.Mp / PlayerAttribute.MaxMp;

        PlayerInfo.transform.GetChild(1).GetChild(2).GetComponent<Text>().text =
            PlayerAttribute.Mp + "/" + PlayerAttribute.MaxMp;
    }
}
