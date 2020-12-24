using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewWeapon : MonoBehaviour
{

    public string stageSelect;
    public float movieTime1;
    // Start is called before the first frame update
    void Start()
    {
        MovieStop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovieStop()
    {
        StartCoroutine(MovieCo());
    }

    private IEnumerator MovieCo()
    {
        yield return new WaitForSeconds(movieTime1);
        SceneManager.LoadScene(stageSelect);
    }
}
