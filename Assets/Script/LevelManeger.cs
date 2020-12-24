using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManeger : MonoBehaviour
{

    public static LevelManeger instance;

    public float waitToRespawn;

    public int gemsCollected;
    public int playerLife;
    
    public string stageSelect;
    public string BossStage;
    public string BossEND;
    public bool BossCheck2,BossCheck3;

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gemsCollected = PlayerPrefs.GetInt ("GEM", 0);
        playerLife = PlayerPrefs.GetInt ("LIFE", 0);
    }

    // Update is called once per frame
    void Update()
    {
        UIController.instance.UpdateGemCount();
        UIController.instance.UpdatePlayerLifeCount();
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        if(LevelManeger.instance.playerLife >= 1)
            {
                PlayerController.instance.gameObject.SetActive(false);

                LevelManeger.instance.playerLife -- ;

                UIController.instance.UpdatePlayerLifeCount();

                yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));
                
                UIController.instance.nowLoading.SetActive(true);

                yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));

                UIController.instance.FadeToBlack();

                yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .2f);

                UIController.instance.FadeFromBlack();

                PlayerController.instance.gameObject.SetActive(true);

                PlayerController.instance.transform.position = CheckPointController.instance.spawnPoint;

                PlayerhealthController.instance.currentHealth = PlayerhealthController.instance.maxHealth;

                Enemy3.instance.ResetHP();

                UIController.instance.nowLoading.SetActive(false);
                
                //1-2ボス戦リスタート
                if(BossCheck2 == true)
                {
                    SceneManager.LoadScene(BossStage);
                    PlayerPrefs.SetInt("LIFE", playerLife);
                    PlayerPrefs.Save ();
                }
                 //1-3ボス戦リスタート
                if(BossCheck3 == true)
                {
                    SceneManager.LoadScene(BossStage);
                    PlayerPrefs.SetInt("LIFE", playerLife);
                    PlayerPrefs.Save ();
                }
            }
        else
        {   //残機ゼロ（ゲームオーバー）
            PlayerController.instance.gameObject.SetActive(false);
            yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .2f);
            UIController.instance.FadeToBlack();
            yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .2f);
            UIController.instance.FadeFromBlack();
            SceneManager.LoadScene(stageSelect);
            playerLife = 3;
            gemsCollected = 0;
            PlayerPrefs.SetInt("LIFE", playerLife);
            PlayerPrefs.SetInt("GEM", gemsCollected);
            PlayerPrefs.Save ();
        }
    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        AudioManeger.instance.PlayLevelVictory();

        PlayerController.instance.stopInput = true;

        CameraController.instance.stopFollow = true;

        UIController.instance.stageClearText.SetActive(true);

        yield return new WaitForSeconds(2.8f);

        AudioManeger.instance.PlaySFX(2);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 2.5f);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        PlayerPrefs.SetInt("GEM", gemsCollected);
        PlayerPrefs.SetInt("LIFE", playerLife);
        PlayerPrefs.Save ();

        SceneManager.LoadScene(stageSelect);
    }


  public void BossEnd()
  {
    StartCoroutine(BossEndCo());
  }
  public IEnumerator BossEndCo()
  {
    AudioManeger.instance.PlayLevelVictory();

    CameraController.instance.stopFollow = true;

    UIController.instance.stageClearText.SetActive(true);

    yield return new WaitForSeconds(2.8f);

    AudioManeger.instance.PlaySFX(2);

    UIController.instance.FadeToBlack();

    yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 2.5f);

    PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
    PlayerPrefs.SetInt("GEM", gemsCollected);
    PlayerPrefs.SetInt("LIFE", playerLife);
    PlayerPrefs.Save();

    SceneManager.LoadScene(BossEND);
  }

}
