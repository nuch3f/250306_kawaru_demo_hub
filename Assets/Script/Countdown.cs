using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
    [SerializeField] public float timeLimit;
    public TextMeshProUGUI uiText;
    public Image CutinBg;
    public TextMeshProUGUI CutinText;
    private string startText = "Ready?";
    private string endText = "Time Up!";
    public static float lastingTime;
    private static float remainingTime = 3.0f; // カウントダウン待機（秒）


    // Start is called before the first frame update
    void Start()
    {
        lastingTime = timeLimit;
        remainingTime = 3.0f;
        // カットイン
        CutinText.text = startText;
        CutinBg.enabled = true;
        CutinText.enabled = true;
    }


    private void hideCutIn()
    {
        CutinBg.enabled = false;
        CutinText.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            hideCutIn();
            timeLimit -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeLimit / 60);
            int seconds = Mathf.FloorToInt(timeLimit % 60);
            uiText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            if (timeLimit <= 0)
            {
                timeLimit = 0;
                uiText.text = "00:00";
                TimeUp();
            }
        }            
    }

    void TimeUp()
    {
        // カットイン
        CutinText.text = endText;
        CutinBg.enabled = true;
        CutinText.enabled = true;

        // リザルト画面へ遷移
        StartCoroutine(DelayCoroutine(3.0f, () => {
            SceneManager.LoadScene("Result");
        }));
        
        
    }

    private IEnumerator DelayCoroutine(float seconds, UnityAction callback)
    {
        yield return new WaitForSeconds(seconds);
        callback?.Invoke();
    }

}
