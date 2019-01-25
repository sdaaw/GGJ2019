using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{



    private SceneState currentSceneState;


    public GameObject currentRoom;
    public GameObject nextRoom; //switch


    public void Start() {
        currentSceneState = currentRoom.GetComponent<SceneState>();
    }

    public void Update() {
        
        if(Input.GetKeyUp(KeyCode.Space)) {



        }

    }


    public void SwitchScene() {


        if(currentSceneState.isSolved) {


            //switch room logic here ?? 


            currentSceneState = nextRoom.GetComponent<SceneState>();

            

        } else {


            //loop to whatever

        }


    }

}
