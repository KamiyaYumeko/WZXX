using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//技能按钮
public class Skill : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public int Index;                               //获取技能标签

    public GameObject SkillText;                    //获取技能介绍文本框

    public GameObject SkillGameObject;              //获取技能列表

    public GameObject PlaerGameObject;              //获取玩家
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //根据编号赋值
    public void SkillValue(string name)
    {
        transform.GetComponentInChildren<Text>().text = name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlaerGameObject.GetComponent<Player>().PlayerAttribute.Mp >
            Player.SkilList[Index].Mp)
        {
            Combat.Index = Index;
            Combat.AtcBool = true;
            SkillGameObject.SetActive(false);
            SkillText.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillText.gameObject.SetActive(true);
        SkillText.transform.localPosition = Vector3.zero;
        Text t = SkillText.transform.GetChild(0).GetComponent<Text>();
        t.text = Player.SkilList[Index].Name;
        t.text += "\n" + Player.SkilList[Index].Information;
        if (Player.SkilList[Index].Type!=5)
        {
            t.text += "\n" + "伤害：" + Player.SkilList[Index].Hurt;
        }
        else
        {
            t.text += "\n" + "治疗：" + Player.SkilList[Index].Hurt;
        }

        t.text += "\n" + "消耗：" + Player.SkilList[Index].Mp;
        t.text += "\n" + "等级：" + Player.SkilList[Index].Lv;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SkillText.gameObject.SetActive(false);
    }
}
