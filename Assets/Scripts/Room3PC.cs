using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room3PC : MonoBehaviour {


    Assets.Pixelation.Scripts.Chunky chunky;

    public GameObject sceneCamera;

    public bool isOnPC = false;
    // Start is called before the first frame update
    void Start() {

        sceneCamera = FindObjectOfType<Camera>().gameObject;

        chunky = sceneCamera.GetComponent<Assets.Pixelation.Scripts.Chunky>();

    }

    // Update is called once per frame
    void Update() {

        if (isOnPC) {
            if (Input.GetKeyUp(KeyCode.E) && GameManager.secretFlag) {
                Debug.Log("activate sequence");
                StartCoroutine(PCScene());

            }
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.GetComponent<PlayerController>()) {
            isOnPC = true;
        }

    }

    IEnumerator PCScene() {
        chunky.enabled = !chunky.enabled;
        //audiosource?!
        yield return new WaitForSeconds(0.4f);
        chunky.enabled = !chunky.enabled;
        //audio stop
        yield return new WaitForSeconds(0.4f);
        chunky.enabled = !chunky.enabled;
        //audio start!

        for (int i = 0; i < 100; i++) {
            chunky.Color.r -= 1;
            yield return new WaitForSeconds(0.1f);
        }

        //sceneload
        UnityEngine.SceneManagement.SceneManager.LoadScene("Outro");
    }
}
