using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float EnemyHealth;

    public static EnemyHealthController instance;

    public float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer theSR;

    public GameObject deathEffect;

    public Transform theEnemy;

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDamage()
    {
        if (invincibleCounter <= 0)
        {
            EnemyHealth--;

            if (EnemyHealth <= 0)
            {
                EnemyHealth = 0;

                Instantiate(deathEffect, transform.position, transform.rotation);

                Destroy(gameObject, .0f);

                AudioManeger.instance.PlaySFX(2);
                
            }
            // else
            // {
            //     invincibleCounter = invincibleLength;
            //     theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);

            //     AudioManeger.instance.PlaySFX(3);
            // }

        }
    }
}
