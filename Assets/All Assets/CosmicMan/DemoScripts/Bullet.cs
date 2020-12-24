using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float bulletSpeed;
	private Rigidbody2D rigidbody2d;
	//private GameObject parent;

	// Start is called before the first frame update
	void Start()
    {
		rigidbody2d = GetComponent<Rigidbody2D>();
		//parent = GetComponent<GameObject>();
    }

  void Update()
  {
    transform.position += new Vector3(bulletSpeed * transform.localScale.x * Time.deltaTime * -1, 0f, 0f);
  }

	private void OnBecameInvisible()
	{
		Invoke("Destroy", 0.25f);
	}

	private void Destroy()
	{
		gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		CancelInvoke();
	}
}
