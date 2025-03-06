using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class EnemyHpSlider : MonoBehaviour
{
    
    public Image enemyThumb;
    public Sprite enemySprite;

    private int EnemyHp;
    private int EnemyMaxHp = 6;
    public Slider slider;
    public Button attackBtn;
    public TextMeshProUGUI Ecounter;

    private int max_damage = 6;
    private int mid_damage = 3;
    private int min_damage = 1;

    // コンボ
    public GameObject comboConainer;
    public TextMeshProUGUI comboCountText;
    public ParticleSystem particle;

    private int enemy_num = 9;

    // SE
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioSource audioSource;

    // Dotween
    private Tweener _shakeTweener;
    private Vector3 _initPosition;



    // Start is called before the first frame update
    void Start()
    {
        EnemyHp = EnemyMaxHp;
        //Debug.Log("EnemyHp = " + EnemyHp);
        Gv.count_num = 0;

        Gv.activeEnemyId = Gv.player1.CharaId;
        Gv.activeCharType = Gv.player1.CharType;
        Gv.activeCharTrans = Gv.player1.IsTransform;

        Gv.activeEnemyId = Gv.ghost1.EnemyId;
        Gv.activeEnemyImg = Gv.ghost1.EnemyImg;
        Gv.activeEnemyType = Gv.ghost1.EnemyType;
        Gv.activeEnemyWeak = Gv.ghost1.EnemyWeak;

        // コンボカウンターを非表示
        comboConainer.SetActive(false);
        Gv.comboNum = 0;
        Gv.isComboEnable = false;
        Gv.comboNumHistory = 0;


        // 初期位置を保持
        _initPosition = enemyThumb.transform.position;

    }       

    // Update is called once per frame
    void Update()
    {
        
    }

    // ダメージ量計算
    public int AttackScore(int damage_num)
    {
        Debug.Log("EnemyHp = " + EnemyHp);
        // 敵のタイプと弱点照合
        if (Gv.activeEnemyType == Gv.activeCharType && Gv.activeEnemyWeak == Gv.activeCharTrans)
        {
            damage_num = max_damage;

        }
        else if (Gv.activeEnemyWeak == Gv.activeCharTrans || Gv.activeEnemyWeak == Gv.activeCharTrans)
        {
            damage_num = mid_damage;
        }
        else
        {
            damage_num = min_damage;
        }
        return damage_num;
    }

    // アタックボタン
    public void OnClickAttack()
    {
        int calcDamage = AttackScore(Gv.damage_num);

        EnemyHp = EnemyHp - calcDamage;
        slider.value = EnemyHp;

        if (calcDamage == max_damage)
        {
            ShowCombo();
            ChangeEnemy();


        } else
        {
            StopCombo();
            audioSource.clip = audioClip2;
            audioSource.Play();

        }
        if(EnemyHp <= 1)
        {
            ChangeEnemy();
            StopCombo();
            audioSource.clip = audioClip3;
            audioSource.Play();

        }
    }

    // 敵交代
    public void ChangeEnemy()
    {
        // 画像を揺らす
        var duration = 1.0f;
        var strength = 30.0f;
        var vibrato = 30.0f;
        StartShake(duration, strength, (int)vibrato, 90.0f, true);

        // HP巻き戻し
        EnemyHp = EnemyMaxHp;
        slider.value = EnemyHp;
        Gv.count_num++;
        Ecounter.text = Gv.count_num.ToString().PadLeft(3, '0');

        // 画像差し替え
        int rnd = Random.Range(1, 10);
        string weakpoint;
        enemySprite = Resources.Load<Sprite>("enemy_thumb" + rnd);
        enemyThumb.sprite = enemySprite;
        Gv.activeEnemyId = rnd;
        switch (rnd)
        {
            case 1:
                Gv.activeEnemyType = Gv.ghost1.EnemyType;
                Gv.activeEnemyWeak = Gv.ghost1.EnemyWeak;
                break;
            case 2:
                Gv.activeEnemyType = Gv.ghost2.EnemyType;
                Gv.activeEnemyWeak = Gv.ghost2.EnemyWeak;
                break;
            case 3:
                Gv.activeEnemyType = Gv.ghost3.EnemyType;
                Gv.activeEnemyWeak = Gv.ghost3.EnemyWeak;
                break;
            case 4:
                Gv.activeEnemyType = Gv.ghost4.EnemyType;
                Gv.activeEnemyWeak = Gv.ghost4.EnemyWeak;
                break;
            case 5:
                Gv.activeEnemyType = Gv.ghost5.EnemyType;
                Gv.activeEnemyWeak = Gv.ghost5.EnemyWeak;
                break;
            case 6:
                Gv.activeEnemyType = Gv.ghost6.EnemyType;
                Gv.activeEnemyWeak = Gv.ghost6.EnemyWeak;
                break;
            case 7:
                Gv.activeEnemyType = Gv.ghost7.EnemyType;
                Gv.activeEnemyWeak = Gv.ghost7.EnemyWeak;
                break;
            case 8:
                Gv.activeEnemyType = Gv.ghost8.EnemyType;
                Gv.activeEnemyWeak = Gv.ghost8.EnemyWeak;
                break;
            case 9:
                Gv.activeEnemyType = Gv.ghost9.EnemyType;
                Gv.activeEnemyWeak = Gv.ghost9.EnemyWeak;
                break;
        }
        Debug.Log("activeCharType = " + Gv.activeCharType);
        Debug.Log("activeEnemyType = " + Gv.activeEnemyType);
        Debug.Log("activeCharTrans = " + Gv.activeCharTrans);
        Debug.Log("activeEnemyWeak = " + Gv.activeEnemyWeak);
        Debug.Log("Gv.ghost1.EnemyType = " + Gv.ghost1.EnemyType);
        Debug.Log("Gv.player1.charType = " + Gv.player1.CharType);

    }

    // コンボ処理
    public void ShowCombo()
    {
        if (!comboConainer.activeSelf)
        {
            comboConainer.SetActive(true);
            Gv.isComboEnable = true;
        }

        Gv.comboNum++;
        if(Gv.comboNum > Gv.comboNumHistory)
        {
            Gv.comboNumHistory = Gv.comboNum;
        }
        comboCountText.text = Gv.comboNum.ToString().PadLeft(2, '0');
        particle.Play();
    }
    // コンボ終了
    public void StopCombo()
    {
        comboConainer.SetActive(false);
        Gv.comboNum = 0;
    }

    public void StartShake(float duration, float strength, int vibrato, float randomness, bool fadeOut)
    {
        // 前回の処理が残っていれば停止して初期位置に戻す
        if (_shakeTweener != null)
        {
            _shakeTweener.Kill();
            enemyThumb.transform.position = _initPosition;
        }
        // 揺れ開始
        _shakeTweener = enemyThumb.transform.DOShakePosition(duration, strength, vibrato, randomness, fadeOut);
    }


}
