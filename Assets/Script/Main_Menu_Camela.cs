using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Camela : MonoBehaviour
{
  public Transform[] points;
  public float moveSpeed;
  public int currentPoint;

  public Transform platform;

  public SpriteRenderer theSR;
  
  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

    if (Vector3.Distance(platform.position, points[currentPoint].position) < .05f)
    {
      currentPoint++;

      if (currentPoint >= points.Length)
      {
        currentPoint = 0;
      }
    }

    if (currentPoint == 1)
    {
      theSR.flipX = true;
    }
    else if (currentPoint == 2)
    {
      theSR.flipX = false;
    }
  }
}
