using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{

    public string stage2, stage3;

    public GameObject gun1;
 
    public GameObject StageClear2,StageClear3;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("1-2_unlocked")||PlayerPrefs.HasKey("BossBattle1_unlocked"))
        {
            StageClear2.SetActive(true);
        }
        if(PlayerPrefs.HasKey("1-3_unlocked")||PlayerPrefs.HasKey("BossBattle3_unlocked"))
        {
            StageClear3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageSelect2()
    {
        StartCoroutine(StageSelectCo2());
    }

    private IEnumerator StageSelectCo2()
    {
        AudioManeger.instance.PlaySFX(6);
        gun1.SetActive(true);
        yield return new WaitForSeconds(2.8f);
        SceneManager.LoadScene(stage2);
    }


    public void StageSelect3()
    {
        StartCoroutine(StageSelectCo3());
    }

    private IEnumerator StageSelectCo3()
    {
        AudioManeger.instance.PlaySFX(6);
        gun1.SetActive(true);
        yield return new WaitForSeconds(2.8f);
        SceneManager.LoadScene(stage3);
    }
}
