using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{


    public Image fadeImage;

    public Vector3 roomPosition = new Vector3(0, 0, 0);

    private SceneState currentSceneState;

    public GameObject sceneCamera;

    public List<SceneState> roomList = new List<SceneState>();



    public GameObject currentRoom;
   // public GameObject nextRoom; //switch to this on solve


    public void Start() {
        currentSceneState = currentRoom.GetComponent<SceneState>();
    }

    public void Update() {
        
        if(Input.GetKeyUp(KeyCode.Space)) {
            SwitchScene();
        }

    }


    public void SwitchScene() {


        if(currentSceneState.isSolved) {


            Debug.Log("SWITCHED SOLVED SCENE");

            StartCoroutine("RoomTransition");
            //switch room logic here ?? joo


            //currentSceneState = nextRoom.GetComponent<SceneState>();

            //go to next scene based on door we enter
            //disable player
            //fade and load new scene

            //currentSceneState = getStateWithId(currentRoom.GetComponent<SceneState>().door1TravelId);
            //currentSceneState = getStateWithId(currentRoom.GetComponent<SceneState>().door2TravelId);


        } else {

            Debug.Log("SWITCHED UNSOLVED SCENE");

        }


    }

    public SceneState getStateWithId(int id)
    {
        for (int i = 0; i < roomList.Count; i++)
            if (id == roomList[i].cID)
                return roomList[i];
        return null;
    }

    IEnumerator RoomTransition() {

        for(float i = 0; i < 1f; i += 0.01f) {
            fadeImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }

        //set new room here?


        for (float i = 1f; i >= 0f; i -= 0.01f) {
            fadeImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }


        //Instantiate(nextRoom, roomPosition, Quaternion.identity);

    }

}
