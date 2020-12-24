using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerhealthController : MonoBehaviour
{

    public static PlayerhealthController instance;

    public int currentHealth, maxHealth;

    public int MP1,maxMP1,MP2,maxMP2;

    public float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer theSR;

    public GameObject deathEffect;

    public Transform thePlayer;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        MP1 = maxMP1;

        MP2 = maxMP2;

        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
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

    public void DealDamage()
    {
        if (invincibleCounter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                transform.parent = null;

                Instantiate(deathEffect, transform.position, transform.rotation);

                AudioManeger.instance.PlaySFX(2);

                LevelManeger.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);

                PlayerController.instance.KnockBack();

                AudioManeger.instance.PlaySFX(3);
            }
        }
    }

        public void HealPlayer()
    {
        //currentHealth = maxHealth;
        currentHealth++;
        AudioManeger.instance.PlaySFX(4);
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

        public void HealPlayerMP()
    {
        //currentHealth = maxHealth;
        MP1 += 3;
        AudioManeger.instance.PlaySFX(4);
        if(MP1 > maxMP1)
        {
            MP1 = maxMP1;
        }
        MP2 += 3;
        AudioManeger.instance.PlaySFX(4);
        if(MP2 > maxMP2)
        {
            MP2 = maxMP2;
        }

    }

        private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }
}
