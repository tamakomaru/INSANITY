using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossBattle : MonoBehaviour
{
    public GameObject leftwall,rightwall;
    public GameObject BossHP;
    public GameObject levelEnd;

    public static BossBattle instance;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LevelManeger.instance.BossCheck2 = true;
            CameraController.instance.changeBossCamera();
            leftwall.SetActive(true);
            rightwall.SetActive(true);
            BossHP.SetActive(true);
            AudioManeger.instance.PlayBossBattle();
            Boss_CosmicMan.instance.BossBattleStart();
        }
    }


}
