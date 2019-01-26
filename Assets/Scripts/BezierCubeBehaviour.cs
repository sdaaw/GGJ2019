using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCubeBehaviour : MonoBehaviour {


    public static Material myMaterial;


    public float offsetX;
    public float offsetY;



    private bool faded = true;


    int randVal;
    private float alphaVal = 0;
    // Start is called before the first frame update
    void Start() {
        myMaterial = GetComponent<Renderer>().material;
        myMaterial.color = new Color(Random.Range(0.5f, 0.8f), 0, Random.Range(0.5f, 0.8f), 1f);
    }

    void FixedUpdate() {
        //?!!!!!!!!!!!!!!!!!!!!!!!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?
        if (alphaVal < 1f && faded) {
            alphaVal += 1f * Time.deltaTime;
        } else {
            faded = false;  
            alphaVal -= 1f * Time.deltaTime;
        }
        if (alphaVal < 0 && !faded) {
            Destroy(gameObject);
        }
        myMaterial.color = new Color(myMaterial.color.r, myMaterial.color.g, myMaterial.color.b, alphaVal);
    }
}
