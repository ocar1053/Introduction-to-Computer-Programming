using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{

    // Start is called before the first frame update
    public void resume()
    {
        gameObject.SetActive(false); //關閉pausemenu
        Time.timeScale = 1f; //讓遊戲重啟時間
    }
}
