using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{


    public Vector3 roomPosition = new Vector3(0, 0, 0);

    private SceneState currentSceneState;

    public List<GameObject> roomList = new List<GameObject>();

    public GameObject currentRoom;
    public GameObject nextRoom; //switch to this on solve


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

            //switch room logic here ?? 


            currentSceneState = nextRoom.GetComponent<SceneState>();
            StartCoroutine("RoomTransition");
            

        } else {

            Debug.Log("SWITCHED UNSOLVED SCENE");

        }


    }

    IEnumerator RoomTransition() {


        yield return new WaitForSeconds(1f);
        Debug.Log("Transition");
        for(float i = 0; i < 1f; i+=0.01f) {


            currentRoom.transform.rotation = new Quaternion(currentRoom.transform.rotation.x + Mathf.Sin(i * 10) * 2, currentRoom.transform.rotation.y, currentRoom.transform.rotation.z, currentRoom.transform.rotation.w);

            yield return new WaitForSeconds(0.05f);
        }
        //Instantiate(nextRoom, roomPosition, Quaternion.identity);

    }

}
