using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToIngameScene : MonoBehaviour
{
    public void btn_change_ingame()
    {
        //Countdown.CountTime = Gv.defaultTimer;
        //Gv.count_num = 0;
        //Gv.comboNum = 0;
        SceneManager.LoadScene("Ingame");
    }
    
    //public void RetryGame()
    //{
    //    Countdown.timer = Countdown.CountTime;
    //    Gv.count_num = 0;
    //    Gv.comboNum = 0;
    //    Countdown.CutinText.text = Countdown.startText;
    //    SceneManager.LoadScene("Start");
    //}
    
}
