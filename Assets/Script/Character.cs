using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    
    // フィールド
    private int charId;
    private string charImg;
    private string charType;
    private bool isTransform = false;
    
    // コンストラクタ
    public Character(
        int charId, 
        string name,
        string charImg,
        string charType,
        bool isTransform
    )
    {
        CharaId = charId;
        Name = name;
        CharImg = charImg;
        CharType = charType;
        IsTransform = isTransform;

    }

    // プロパティ
    public int CharaId;
    public string Name;
    public string CharImg;
    public string CharType;
    public bool IsTransform = false;
    
    
}
