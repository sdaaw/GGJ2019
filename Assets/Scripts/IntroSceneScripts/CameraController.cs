using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{



    public int moveAmount = 2;
    private Vector3 originalLocation = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        originalLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(originalLocation, new Vector3(originalLocation.x + Random.Range(-moveAmount, moveAmount), 
            originalLocation.y + Random.Range(-moveAmount, moveAmount), 
            originalLocation.z + Random.Range(-moveAmount, moveAmount)), Time.deltaTime);



    }
}
