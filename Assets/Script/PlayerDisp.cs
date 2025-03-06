using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisp : MonoBehaviour
{
    // キャラ変更ボタンの処理
    public Button charChangeBtn;
    public Image charThumb;
    public int selectedCharId;
    public int charMaxNum = 4;
    public Sprite newSprite;
    public string selectedCharaThumb;
    public bool selectedCharaTrans;
    public string playerTemp;

    // Start is called before the first frame update
    void Start()
    {
        selectedCharId = 1;
        selectedCharaTrans = false;
        selectedCharaThumb = Gv.player1.CharImg;
    }


    // キャラ交代
    public void SetCharacterThumb()
    {
        if (selectedCharId == charMaxNum)
        {
            selectedCharId = 1;
        }
        else
        {
            selectedCharId++;
        }

        Gv.activeCharId = selectedCharId;

        switch (selectedCharId)
        {
            case 1:
                selectedCharaThumb = Gv.player1.CharImg;
                Gv.activeCharType = Gv.player1.CharType;
                Gv.activeCharTrans = Gv.player1.IsTransform;
                break;
            case 2:
                selectedCharaThumb = Gv.player2.CharImg;
                Gv.activeCharType = Gv.player2.CharType;
                Gv.activeCharTrans = Gv.player2.IsTransform;
                break;
            case 3:
                selectedCharaThumb = Gv.player3.CharImg;
                Gv.activeCharType = Gv.player3.CharType;
                Gv.activeCharTrans = Gv.player3.IsTransform;
                break;
            case 4:
                selectedCharaThumb = Gv.player4.CharImg;
                Gv.activeCharType = Gv.player4.CharType;
                Gv.activeCharTrans = Gv.player4.IsTransform;
                break;
        }

        newSprite = Resources.Load<Sprite>(selectedCharaThumb);
        charThumb.sprite = newSprite;
    }

    // キャラタイプの変更
    public void ChangeCharType()
    {
        selectedCharId = Gv.activeCharId;

        switch (selectedCharId)
        {
            case 1:
                selectedCharaThumb = Gv.player1.CharImg;
                Gv.activeCharType = Gv.player1.CharType;
                Gv.activeCharTrans = Gv.player1.IsTransform;
                break;
            case 2:
                selectedCharaThumb = Gv.player2.CharImg;
                Gv.activeCharType = Gv.player2.CharType;
                Gv.activeCharTrans = Gv.player2.IsTransform;
                break;
            case 3:
                selectedCharaThumb = Gv.player3.CharImg;
                Gv.activeCharType = Gv.player3.CharType;
                Gv.activeCharTrans = Gv.player3.IsTransform;
                break;
            case 4:
                selectedCharaThumb = Gv.player4.CharImg;
                Gv.activeCharType = Gv.player4.CharType;
                Gv.activeCharTrans = Gv.player4.IsTransform;
                break;
        }

        // 変身ボタンで状態をトグル
        if (selectedCharaTrans)
        {
            selectedCharaTrans = false;
            Gv.activeCharTrans = false;
            newSprite = Resources.Load<Sprite>(selectedCharaThumb);
        }
        else
        {
            selectedCharaTrans = true;
            Gv.activeCharTrans = true;
            newSprite = Resources.Load<Sprite>(selectedCharaThumb + "_t");
        }
        charThumb.sprite = newSprite;

        Debug.Log("activeCharType = " + Gv.activeCharType);
        Debug.Log("activeEnemyType = " + Gv.activeEnemyType);
        Debug.Log("activeCharTrans = " + Gv.activeCharTrans);
        Debug.Log("activeEnemyWeak = " + Gv.activeEnemyWeak);
    }
}