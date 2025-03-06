using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

static public class Gv 
{
    static public int count_num;
    static public int damage_num;
    static public int selectedCharId;
    static public int comboNum;
    static public bool isComboEnable;
    static public int comboNumHistory;

    // 選択中のキャラクター
    public static int activeCharId;
    public static Image activeCharImg;
    public static string activeCharType;
    public static bool activeCharTrans;
    // 出現中の敵
    public static int activeEnemyId;
    public static string activeEnemyImg;
    public static string activeEnemyType;
    public static bool activeEnemyWeak;

    static public int defaultTimer = 10;

    // キャラのインスタンス作成
    static public Character player1 = new Character(1, "Succubus", "char_thumb1", "type1", false);
    static public Character player2 = new Character(2, "Vampire", "char_thumb2", "type2", false);
    static public Character player3 = new Character(3, "Tarantula", "char_thumb3", "type3", false);
    static public Character player4 = new Character(4, "Wolfman", "char_thumb4", "type4", false);
    static public Enemy ghost1 = new Enemy(1, "enemy_thumb1", "type4", false);
    static public Enemy ghost2 = new Enemy(2, "enemy_thumb2", "type3", false);
    static public Enemy ghost3 = new Enemy(3, "enemy_thumb3", "type2", false);
    static public Enemy ghost4 = new Enemy(4, "enemy_thumb4", "type1", false);
    static public Enemy ghost5 = new Enemy(5, "enemy_thumb5", "type1", false);
    static public Enemy ghost6 = new Enemy(6, "enemy_thumb6", "type2", true);
    static public Enemy ghost7 = new Enemy(7, "enemy_thumb7", "type3", true);
    static public Enemy ghost8 = new Enemy(8, "enemy_thumb8", "type4", true);
    static public Enemy ghost9 = new Enemy(9, "enemy_thumb9", "type1", true);
}
