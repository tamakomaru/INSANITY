﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyaerChargeBullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }
}