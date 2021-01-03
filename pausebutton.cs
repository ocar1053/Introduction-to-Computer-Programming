using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausebutton : MonoBehaviour
{

    public GameObject gameObject;
    public void pause()
    {
        gameObject.SetActive(true);  //開啟pausemenu
        Time.timeScale = 0f; //使遊戲時間暫停
    }
}
