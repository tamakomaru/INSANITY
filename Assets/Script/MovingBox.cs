using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{

    public GameObject cover;

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
    if (other.tag == "Player")
		{
            cover.SetActive(false);
            AudioManeger.instance.PlaySFX(22);
		}
	}
}
