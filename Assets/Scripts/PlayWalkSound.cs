using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWalkSound : MonoBehaviour
{
    private Rigidbody r;
    public AudioSource aSource;

    private void Start()
    {
        r = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (r.velocity.magnitude > 0.5f && !aSource.isPlaying)
            aSource.Play();
    }
}
