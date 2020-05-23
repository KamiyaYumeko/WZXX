using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//场景上可点击敌人
public class NPCEnemy : MonoBehaviour
{
    public GameObject Manager;                              
    //攻击敌人
    public void Atk()
    {
        int[,] num=new int[1,6];
        for (int i = 0; i < 6; i++)
        {
            num[0, i] = 0;
        }

        num[0, 5] = -1;
        StartCoroutine(Manager.GetComponent<GameManager>().CombatSystem(num));
    }
}
