using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossBattle3 : MonoBehaviour
{
    public GameObject leftwall,rightwall,startPoint;
    public GameObject BossHP;
    public GameObject levelEnd;

    public static BossBattle3 instance;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UIController.instance.BossHP <= 0)
        {
            levelEnd.SetActive(true);
        }
    }

    public void BossBattleStart()
    {
            LevelManeger.instance.BossCheck3 = true;
            CameraController.instance.changeBossCamera();
            leftwall.SetActive(true);
            rightwall.SetActive(true);
            BossHP.SetActive(true);
            startPoint.SetActive(false);
            AudioManeger.instance.PlayBossBattle();
            Boss_Vincent.instance.BossBattleStart();
    }


}
