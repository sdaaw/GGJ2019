using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int doorId;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            //TODO: scene manager. change scene
            FindObjectOfType<SceneManager>().SwitchScene(doorId);
        }
    }
}
