using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform target;

    public Transform farBackground, middleBackground1,middleBackground2,nearBackground;

    public float minHeight, maxHeight;

    public bool stopFollow;

    //private float lastXPos;
    private Vector2 lastPos;

    public Transform bossCamera,player;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopFollow)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

            farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
            middleBackground1.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;
            middleBackground2.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .4f;
            nearBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .3f;

            lastPos = transform.position;
        }
    }

    public void changeBossCamera()
    {
        target = bossCamera;
    }

    public void changePlayerCamera()
    {
        target = player;
    }

    
}
