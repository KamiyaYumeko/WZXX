using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//开始游戏界面
public class Button : MonoBehaviour
{
    //开始游戏
    public void StartGame()
    {
        SceneManager.LoadScene("game");
    }

    //退出游戏
    public void QuitGame()
    {
        Application.Quit();
    }
}
