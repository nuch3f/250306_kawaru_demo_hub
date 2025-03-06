using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultView : MonoBehaviour
{
    private int escape_num;
    private int max_combo_num;
    public TextMeshProUGUI resultEscapeCounter;
    public TextMeshProUGUI resultComboCounter;
    public Image awardImg1;
    public Image awardImg2;
    public Image awardImg3;
    public Image awardImg4;
    public Image awardMedal;
    private Sprite awardMedalImg;
    public Image awardTitle1;
    public Image awardTitle2;
    public Image awardTitle3;
    public Image awardTitle4;
    private string awardPath;

    private int award1st_num = 100;
    private int award2nd_num = 50;
    private int award3rd_num = 30;

    // Start is called before the first frame update
    void Start()
    {
        escape_num = Gv.count_num;
        resultEscapeCounter.text = escape_num.ToString().PadLeft(3, '0');
        max_combo_num = Gv.comboNumHistory;
        resultComboCounter.text = max_combo_num.ToString().PadLeft(3, '0');

        // 称号を非表示
        awardTitle1.enabled = false;
        awardTitle2.enabled = false;
        awardTitle3.enabled = false;
        awardTitle4.enabled = false;

        // メダル画像差し替え
        int awardNum = ShowAwardName(Gv.count_num);
        
        switch (awardNum)
        {
            case 1:
                awardPath = "1st";
                awardTitle1.enabled = true;
                break;
            case 2:
                awardPath = "2nd";
                awardTitle2.enabled = true;
                break;
            case 3:
                awardPath = "3rd";
                awardTitle3.enabled = true;
                break;
            case 4:
                awardPath = "4th";
                awardTitle4.enabled = true;
                break;
        }
        awardMedalImg = Resources.Load<Sprite>(awardPath);
        awardMedal.sprite = awardMedalImg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 称号チェック
    public int ShowAwardName(int rankNum)
    {
        if(Gv.count_num > award1st_num)
        {
            rankNum = 1;
        }else if(Gv.count_num > award2nd_num)
        {
            rankNum = 2;   
        }else if(Gv.count_num > award3rd_num)
        {
            rankNum = 3;
        }
        else
        {
            rankNum = 4;
        }
        
        return rankNum;
    } 
}
