using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//技能表
public class SSkill : MonoBehaviour
{
    public GameObject SkillPref;                            //获取技能预制体

    public GameObject GfPref;                               //获取功法预制体

    public GameObject SkillParent;                          //技能按钮设置父节点

    public GameObject SkillText;                            //获取技能介绍文本框

    //清空技能表
    private void ClearSkill()
    {
        for (int i = 0; i < SkillParent.transform.childCount; i++)
        {
            Destroy(SkillParent.transform.GetChild(i).gameObject);
        }
    }

    //筛选技能
    private void SelectSkill(int type)
    {
        for (int i = 0; i < Player.SkilList.Count; i++)
        {
            if (Player.SkilList[i].Type==type)
            {
                GameObject obj = Instantiate(SkillPref);
                obj.GetComponent<Skill>().Index = i;
                obj.GetComponent<Skill>().SkillValue(Player.SkilList[i].Name);
                obj.GetComponent<Skill>().SkillText = SkillText;
                obj.transform.SetParent(SkillParent.transform);
            }
        }
    }

    //全部技能
    public void AllSkill()
    {
        ClearSkill();
        foreach (var s in Player.SkilList)
        {
            GameObject obj = Instantiate(SkillPref);
            obj.GetComponent<Skill>().Index = s.Id;
            obj.GetComponent<Skill>().SkillValue(s.Name);
            obj.GetComponent<Skill>().SkillText = SkillText;
            obj.transform.SetParent(SkillParent.transform);
        }
    }

    //剑法
    public void SwordSkill()
    {
        ClearSkill();
        SelectSkill(1);
    }

    //刀法
    public void KnifeSkill()
    {
        ClearSkill();
        SelectSkill(2);
    }

    //棍法
    public void StickSkill()
    {
        ClearSkill();
        SelectSkill(3);
    }

    //暗器
    public void BackstabberSkill()
    {
        ClearSkill();
        SelectSkill(4);
    }

    //医术
    public void LeechcraftSkill()
    {
        ClearSkill();
        SelectSkill(5);
    }

    //毒术
    public void PoisoningSkill()
    {
        ClearSkill();
        SelectSkill(6);
    }

    //心法
    public void XingfaSkill()
    {
        ClearSkill();
        foreach (var g in Player.GfList)
        {
            GameObject obj = Instantiate(GfPref);
            obj.GetComponent<GF>().Index = g.Id;
            obj.GetComponent<GF>().GfValue(g.Name);
            obj.transform.SetParent(SkillParent.transform);
        }
    }
}
