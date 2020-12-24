using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_CosmicMan : MonoBehaviour
{
    public GameObject deathEffect;

    public GameObject collectible;

    private SpriteRenderer theSR;

    public float hitLength;
    private float hitCounter;

    public static Boss_CosmicMan instance;

    private Animator anim;

    public GameObject bullet,bullet2,blackHole;
    public Transform firePoint,firePoint2,blackHolePoint1,blackHolePoint2,blackHolePoint3,blackHolePoint4,blackHolePoint5;

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
                AudioManeger.instance.PlaySFX(5);
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
        yield return new WaitForSeconds(4.5f);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(14);
        yield return new WaitForSeconds(1f);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(14);
        yield return new WaitForSeconds(1f);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(14);
        yield return new WaitForSeconds(1f);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(14);
        yield return new WaitForSeconds(3.5f);
        Instantiate(blackHole, blackHolePoint1.position, blackHolePoint1.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint2.position, blackHolePoint2.rotation);
        Instantiate(blackHole, blackHolePoint5.position, blackHolePoint4.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint3.position, blackHolePoint3.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint4.position, blackHolePoint4.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint1.position, blackHolePoint1.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint2.position, blackHolePoint2.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint3.position, blackHolePoint3.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint4.position, blackHolePoint4.rotation);
        Instantiate(blackHole, blackHolePoint2.position, blackHolePoint2.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint1.position, blackHolePoint1.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint2.position, blackHolePoint2.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint3.position, blackHolePoint3.rotation);
        Instantiate(blackHole, blackHolePoint5.position, blackHolePoint4.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint4.position, blackHolePoint4.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint2.position, blackHolePoint2.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint3.position, blackHolePoint3.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint4.position, blackHolePoint4.rotation);
        Instantiate(blackHole, blackHolePoint2.position, blackHolePoint2.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint1.position, blackHolePoint1.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint2.position, blackHolePoint2.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint3.position, blackHolePoint3.rotation);
        Instantiate(blackHole, blackHolePoint5.position, blackHolePoint4.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(0.3f);
        Instantiate(blackHole, blackHolePoint4.position, blackHolePoint4.rotation);
        AudioManeger.instance.PlaySFX(15);
        yield return new WaitForSeconds(4f);
        Instantiate(bullet2, firePoint2.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(14);
        yield return new WaitForSeconds(1f);
        Instantiate(bullet2, firePoint2.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(14);
        yield return new WaitForSeconds(1f);
        Instantiate(bullet2, firePoint2.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(14);
        yield return new WaitForSeconds(1f);
        Instantiate(bullet2, firePoint2.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(14);
        yield return new WaitForSeconds(1f);
        Instantiate(bullet2, firePoint2.position, firePoint.rotation);
        AudioManeger.instance.PlaySFX(14);
        yield return new WaitForSeconds(6f);
        BossBattleStart();
        
    }
    

}

