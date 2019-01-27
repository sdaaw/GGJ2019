using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ending());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(56f);
        Application.Quit();
    }
}
