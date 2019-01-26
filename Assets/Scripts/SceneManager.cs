using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{


    public Image fadeImage;

    public Vector3 roomPosition = new Vector3(0, 0, 0);
    public Vector3 roomRotation = new Vector3(0, 0, 0);

    private SceneState currentSceneState;

    public GameObject sceneCamera;

    public List<SceneState> roomList = new List<SceneState>();



    public GameObject currentRoom;
   // public GameObject nextRoom; //switch to this on solve


    public void Start() {
        currentSceneState = roomList[0];
        currentRoom = Instantiate(currentSceneState.gameObject, roomPosition, Quaternion.Euler(roomRotation));

    }

    public void Update() {
        
        if(Input.GetKeyUp(KeyCode.Space)) {
            //SwitchScene();
        }

    }


    public void SwitchScene(int doorId) {


        if(currentSceneState.isSolved) {

            //currentSceneState = nextRoom.GetComponent<SceneState>();

            //go to next scene based on door we enter
            //disable player
            //fade and load new scene

            StartCoroutine(RoomTransition(doorId));

        } else {

            Debug.Log("SWITCHED UNSOLVED SCENE");

        }


    }

    public SceneState getStateWithId(int id)
    {
        for (int i = 0; i < roomList.Count; i++)
            if (id == roomList[i].sceneId)
                return roomList[i];
        return null;
    }

    IEnumerator RoomTransition(int id) {

        for(float i = 0; i < 1f; i += 0.01f) {
            fadeImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }

        //set new room here?
        Destroy(currentRoom);

        if (id == 1)
        {
            currentSceneState = getStateWithId(currentRoom.GetComponent<SceneState>().door1TravelId);
        }
        else if (id == 2)
        {
            currentSceneState = getStateWithId(currentRoom.GetComponent<SceneState>().door2TravelId);
        }


        currentRoom = Instantiate(currentSceneState.gameObject, roomPosition, Quaternion.Euler(roomRotation));

        //change playermodel and place it to start position

        for (float i = 1f; i >= 0f; i -= 0.01f) {
            fadeImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }

        //currentRoom = Instantiate(currentSceneState.gameObject, roomPosition, Quaternion.identity);

    }

}
