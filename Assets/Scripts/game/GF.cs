using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//功法
public class GF : MonoBehaviour
{
    public int Index;                               //获取技能标签
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //根据编号赋值
    public void GfValue(string name)
    {
        transform.GetComponentInChildren<Text>().text = name;
    }
}
