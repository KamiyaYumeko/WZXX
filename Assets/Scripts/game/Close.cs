using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//隐藏面板
public class Close : MonoBehaviour
{
    public void CloseAttribute()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
