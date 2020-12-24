using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public bool isGem, isHeal,isMP;

    // private bool isCollected;

    public GameObject pickupEffect;

    public Transform effectPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        {  
            if (isHeal)
            {
                if (other.tag == "Player")
                {
                    PlayerhealthController.instance.HealPlayer();
                    Destroy(gameObject);
                    Instantiate(pickupEffect, effectPosition.position, transform.rotation);

                }
            }
        }

            if (isGem)
            {
                if (other.tag == "Player")
                {   
                    LevelManeger.instance.gemsCollected ++;
                    Destroy(gameObject);
                    Instantiate(pickupEffect, effectPosition.position, transform.rotation);
                    UIController.instance.UpdateGemCount();
                    AudioManeger.instance.PlaySFX(11);
                }
            }

            if (isMP)
            {
                if (other.tag == "Player")
                {
                    PlayerhealthController.instance.HealPlayerMP();
                    Destroy(gameObject);
                    Instantiate(pickupEffect, effectPosition.position, transform.rotation);
                }
            }
    }
}
