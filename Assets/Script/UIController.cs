using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image HPBar;
 
    public Image MP1,MP2;

    public int BossHP;//ボス体力

    public Image BossHPBar; //ボス体力ゲージ表示

    public Image EnergyBar;

    public Text gemText;

    public Text playerLifeText;

    public GameObject nowLoading;

    public bool isNowLoading;

    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    public GameObject stageClearText;

    public GameObject maxText;

    public int weapon1;

    public GameObject weaponMP1,weaponMP2;

    public bool Clear2,Clear3;
    

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    UpdateGemCount();
    UpdatePlayerLifeCount();
    FadeFromBlack();
    StageClearLog();
    weapon1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if(shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }

        switch(PlayerhealthController.instance.currentHealth)
        {

            case 5:
                HPBar.fillAmount = 1;
                HPBar.color = new Color(0.06f, 1.0f, 0f, 1.0f);
            break;

            case 4:
                HPBar.fillAmount = 0.8f;
                HPBar.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
            break;

            case 3:
                HPBar.fillAmount = 0.6f;
                HPBar.color = new Color(1.0f, 1f, 0.01f, 1.0f);
            break;

            case 2:
                HPBar.fillAmount = 0.4f;
                HPBar.color = new Color(1.0f, 0.6f, 0.01f, 1.0f);
            break;

            case 1:
                HPBar.fillAmount = 0.2f;
                HPBar.color = new Color(1.0f, 0.0f, 0.0f, 1f);
            break;

            case 0:
                HPBar.fillAmount = 0;
            break;
        }

        switch(PlayerhealthController.instance.MP1)
        {

            case 15:
                MP1.fillAmount = 1;
            break;

            case 14:
                MP1.fillAmount = 0.94f;
            break;

            case 13:
                MP1.fillAmount = 0.88f;
            break;

            case 12:
                MP1.fillAmount = 0.82f;
            break;

            case 11:
                MP1.fillAmount = 0.76f;
            break;

            case 10:
                MP1.fillAmount = 0.7f;
            break;

            case 9:
                MP1.fillAmount = 0.63f;
            break;

            case 8:
                MP1.fillAmount = 0.57f;
            break;

            case 7:
                MP1.fillAmount = 0.5f;
            break;

            case 6:
                MP1.fillAmount = 0.44f;
            break;

            case 5:
                MP1.fillAmount = 0.38f;
            break;

            case 4:
                MP1.fillAmount = 0.3f;
            break;

            case 3:
                MP1.fillAmount = 0.23f;
            break;

            case 2:
                MP1.fillAmount = 0.17f;
            break;

            case 1:
                MP1.fillAmount = 0.8f;
            break;

            case 0:
                MP1.fillAmount = 0f;
            break;
        }
        switch(PlayerhealthController.instance.MP2)
        {

            case 15:
                MP2.fillAmount = 1;
            break;

            case 14: 
                MP2.fillAmount = 0.94f;
            break;

            case 13:
                MP2.fillAmount = 0.88f;
            break;

            case 12:
                MP2.fillAmount = 0.82f;
            break;

            case 11:
                MP2.fillAmount = 0.76f;
            break;

            case 10:
                MP2.fillAmount = 0.7f;
            break;

            case 9:
                MP2.fillAmount = 0.63f;
            break;

            case 8:
                MP2.fillAmount = 0.57f;
            break;

            case 7:
                MP2.fillAmount = 0.5f;
            break;

            case 6:
                MP2.fillAmount = 0.44f;
            break;

            case 5:
                MP2.fillAmount = 0.38f;
            break;

            case 4:
                MP2.fillAmount = 0.3f;
            break;

            case 3:
                MP2.fillAmount = 0.23f;
            break;

            case 2:
                MP2.fillAmount = 0.17f;
            break;

            case 1:
                MP2.fillAmount = 0.8f;
            break;

            case 0:
                MP2.fillAmount = 0f;
            break;
        }

        switch(PlayerController.instance.shotCharge)
        {

            case 140:
                EnergyBar.fillAmount = 1f;
                EnergyBar.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            break;

            case 120:
                EnergyBar.fillAmount = 0.85f;
                EnergyBar.color = new Color(1.0f, 0.15f, 0.0f, 0.85f);
            break;

            case 100:
                EnergyBar.fillAmount = 0.7f;
                EnergyBar.color = new Color(1.0f, 0.3f, 0.0f, 0.7f);
            break;

            case 80:
                EnergyBar.fillAmount = 0.55f;
                EnergyBar.color = new Color(1.0f, 0.45f, 0.0f, 0.55f);
            break;

            case 60:
                EnergyBar.fillAmount = 0.4f;
                EnergyBar.color = new Color(1.0f, 0.6f, 0.0f, 0.4f);
            break;

            case 40:
                EnergyBar.fillAmount = 0.25f;
                EnergyBar.color = new Color(1.0f, 0.75f, 0.0f, 0.25f);
            break;

            case 20:
                EnergyBar.fillAmount = 0.1f;
                EnergyBar.color = new Color(1.0f, 0.9f, 0.0f, 0.1f);
            break;

            case 0:
                EnergyBar.fillAmount = 0;
                EnergyBar.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            break;
        }


        if ((100 > BossHP)&&( 95 <= BossHP))
        {
            BossHPBar.fillAmount = 1f;
        }
        if ((95 > BossHP)&&( 90 <= BossHP))
        {
            BossHPBar.fillAmount = 0.95f;
        }
        if ((90 > BossHP)&&( 85 <= BossHP))
        {
            BossHPBar.fillAmount = 0.9f;
        }
        if ((85 > BossHP)&&( 80 <= BossHP))
        {
            BossHPBar.fillAmount = 0.85f;
        }
        if ((80 > BossHP)&&( 75 <= BossHP))
        {
            BossHPBar.fillAmount = 0.8f;
        }
        if ((75 > BossHP)&&( 70 <= BossHP))
        {
            BossHPBar.fillAmount = 0.75f;
        }
        if ((70 > BossHP)&&( 65 <= BossHP))
        {
            BossHPBar.fillAmount = 0.7f;
        }
        if ((65 > BossHP)&&( 60 <= BossHP))
        {
            BossHPBar.fillAmount = 0.65f;
        }
        if ((60 > BossHP)&&( 55<= BossHP))
        {
            BossHPBar.fillAmount = 0.6f;
        }
        if ((55 > BossHP)&&( 50 <= BossHP))
        {
            BossHPBar.fillAmount = 0.55f;
        }
        if ((50 > BossHP)&&( 45 <= BossHP))
        {
            BossHPBar.fillAmount = 0.5f;
        }
        if ((45 > BossHP)&&( 40 <= BossHP))
        {
            BossHPBar.fillAmount = 0.45f;
        }
        if ((40 > BossHP)&&( 35 <= BossHP))
        {
            BossHPBar.fillAmount = 0.4f;
        }
        if ((35 > BossHP)&&( 30 <= BossHP))
        {
            BossHPBar.fillAmount = 0.35f;
        }
        if ((30 > BossHP)&&( 25 <= BossHP))
        {
            BossHPBar.fillAmount = 0.3f;
        }
        if ((25 > BossHP)&&( 20 <= BossHP))
        {
            BossHPBar.fillAmount = 0.25f;
        }
        if ((20 > BossHP)&&( 15 <= BossHP))
        {
            BossHPBar.fillAmount = 0.2f;
        }
        if ((15 > BossHP)&&( 10 <= BossHP))
        {
            BossHPBar.fillAmount = 0.15f;
        }
        if ((10 > BossHP)&&( 5 < BossHP))
        {
            BossHPBar.fillAmount = 0.1f;
        }
        if ((5 > BossHP)&&( 0 < BossHP))
        {
            BossHPBar.fillAmount = 0.05f;
        }
        if (0 >= BossHP)
        {
            BossHPBar.fillAmount = 0f; 
        }

        if(PlayerController.instance.shotCharge >= 140)
        {
            maxText.SetActive(true);
        }else
        {
            maxText.SetActive(false);
        }
        
        

    }
    public void UpdateGemCount()
    {
        gemText.text = LevelManeger.instance.gemsCollected.ToString();
    }
    public void UpdatePlayerLifeCount()
    {
        playerLifeText.text = LevelManeger.instance.playerLife.ToString();
    }


    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

    public void StageClearLog()
    {
        if(PlayerPrefs.HasKey("1-2_unlocked")||PlayerPrefs.HasKey("BossBattle1_unlocked"))
        {
        Clear2 = true;
        }
        if(PlayerPrefs.HasKey("1-3_unlocked")||PlayerPrefs.HasKey("BossBattle3_unlocked"))
        {
        Clear3 = true;
        }
    }

    public void WeaponChange()
    {
        if((Clear2 == true) && (Clear3 == true) )
        {
        weapon1 ++;
            switch(weapon1)
            {
                case 3:
                    weaponMP2.SetActive(false);
                    weapon1 -=3;
                break;

                case 2:
                    weaponMP1.SetActive(false);
                    weaponMP2.SetActive(true);

                break;

                case 1:
                    weaponMP1.SetActive(true);
                break;
            }

        }
    }

    

}
