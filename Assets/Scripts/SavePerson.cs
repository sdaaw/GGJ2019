using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePerson : MonoBehaviour
{
    public int personId;

    void Start()
    {
        switch(personId)
        {
            case 0:
                GameManager.joukoSaved = true;
                break;
            case 1:
                GameManager.mirvaSaved = true;
                break;
            case 2:
                GameManager.pekkaSaved = true;
                break;
        }
    }
}
