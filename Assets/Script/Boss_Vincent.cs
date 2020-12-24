using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Vincent : MonoBehaviour
{
    public GameObject deathEffect;

    public GameObject collectible;

    private SpriteRenderer theSR;

    public float hitLength;
    private float hitCounter;

    public static Boss_Vincent instance;

    private Animator anim;

    public GameObject bullet,bullet2,wind;
    public Transform firePoint,firePoint2,Point1,Point2,Point3,Point4,Point5,Point6,Point7,Point8;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hitCounter > 0)
        {
            hitCounter -= Time.deltaTime;

            if(hitCounter <= 0)
            {
                theSR.color =  new Color(1f,1f,1f,1f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hitCounter <= 0 )
        {
        
            if(other.tag == "Bullet")
            {
                UIController.instance.BossHP --;
                theSR.color =  new Color(1f,1f,1f,0.6f);
                hitCounter = hitLength;
                AudioManeger.instance.PlaySFX(19);
                if (UIController.instance.BossHP <= 0)
                {
                    AudioManeger.instance.PlaySFX(7);
                    Destroy(gameObject);
                    Instantiate(deathEffect, transform.position, transform.rotation);

                }

            }
            if(other.tag == "Charge Bullet")
            {
                UIController.instance.BossHP -= 5;
                AudioManeger.instance.PlaySFX(8);
                if (UIController.instance.BossHP <= 0)
                {
                    AudioManeger.instance.PlaySFX(3);
                    Destroy(gameObject);
                    Instantiate(deathEffect, transform.position, transform.rotation);

                }

            }

            if(other.tag == "Weapon1")
            {
                UIController.instance.BossHP -= 3;
                theSR.color =  new Color(1f,1f,1f,0.6f);
                AudioManeger.instance.PlaySFX(16);
                if (UIController.instance.BossHP <= 0)
                {
                    AudioManeger.instance.PlaySFX(3);
                    Destroy(gameObject);
                    Instantiate(deathEffect, transform.position, transform.rotation);
                }

            }
        }
    }

        public void BossBattleStart()
    {
        StartCoroutine(BossBattleCo());
    }

    public IEnumerator BossBattleCo()
    {
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("Attack1");
        yield return new WaitForSeconds(0.2f);
        AudioManeger.instance.PlaySFX(20);
        yield return new WaitForSeconds(4.2f);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        Instantiate(wind, Point7.position, Point7.rotation);
        Instantiate(wind, Point8.position, Point8.rotation);
        Instantiate(wind, Point1.position, Point1.rotation);
        Instantiate(wind, Point3.position, Point3.rotation);
        Instantiate(wind, Point5.position, Point6.rotation);
        AudioManeger.instance.PlaySFX(21);
        yield return new WaitForSeconds(0.9f);
        Instantiate(bullet, firePoint2.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(21);
        yield return new WaitForSeconds(0.9f);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(21);
        yield return new WaitForSeconds(0.9f);
        Instantiate(bullet, firePoint2.position, firePoint.rotation);
        Instantiate(wind, Point7.position, Point7.rotation);
        Instantiate(wind, Point8.position, Point8.rotation);
        Instantiate(wind, Point1.position, Point1.rotation);
        Instantiate(wind, Point3.position, Point3.rotation);
        Instantiate(wind, Point5.position, Point6.rotation);
        AudioManeger.instance.PlaySFX(21);
        yield return new WaitForSeconds(0.9f);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(21);
        yield return new WaitForSeconds(0.9f);
        Instantiate(bullet, firePoint2.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(21);
        yield return new WaitForSeconds(3.5f);
        Instantiate(wind, Point1.position, Point1.rotation);
        AudioManeger.instance.PlaySFX(23);
        yield return new WaitForSeconds(0.1f);
        Instantiate(wind, Point2.position, Point2.rotation);
        AudioManeger.instance.PlaySFX(23);
        yield return new WaitForSeconds(0.1f);
        Instantiate(wind, Point3.position, Point3.rotation);
        AudioManeger.instance.PlaySFX(23);
        yield return new WaitForSeconds(0.1f);
        Instantiate(wind, Point4.position, Point4.rotation);
        AudioManeger.instance.PlaySFX(23);
        yield return new WaitForSeconds(0.1f);
        Instantiate(wind, Point5.position, Point5.rotation);
        AudioManeger.instance.PlaySFX(23);
        yield return new WaitForSeconds(0.1f);
        Instantiate(wind, Point6.position, Point6.rotation);
        AudioManeger.instance.PlaySFX(23);
        yield return new WaitForSeconds(6.7f);
        AudioManeger.instance.PlaySFX(20);
        yield return new WaitForSeconds(0.7f);
        Instantiate(bullet2, firePoint.position, firePoint.rotation);
        Instantiate(wind, Point7.position, Point7.rotation);
        Instantiate(wind, Point8.position, Point8.rotation);
        Instantiate(wind, Point1.position, Point1.rotation);
        Instantiate(wind, Point3.position, Point3.rotation);
        Instantiate(wind, Point5.position, Point6.rotation);
        AudioManeger.instance.PlaySFX(21);
        yield return new WaitForSeconds(0.8f);
        Instantiate(bullet2, firePoint2.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(21);
        yield return new WaitForSeconds(0.8f);
        Instantiate(bullet2, firePoint.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(21);
        yield return new WaitForSeconds(0.8f);
        Instantiate(bullet2, firePoint2.position, firePoint.rotation);
        Instantiate(wind, Point7.position, Point7.rotation);
        Instantiate(wind, Point8.position, Point8.rotation);
        Instantiate(wind, Point1.position, Point1.rotation);
        Instantiate(wind, Point3.position, Point3.rotation);
        Instantiate(wind, Point5.position, Point6.rotation);
        AudioManeger.instance.PlaySFX(21);
        yield return new WaitForSeconds(2f);
        BossBattleStart();
        
    }
    

}

