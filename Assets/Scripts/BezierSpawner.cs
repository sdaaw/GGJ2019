using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierSpawner : MonoBehaviour
{

    public Vector3 point1;
    public Vector3 point2;
    public Vector3 point3;
    public Vector3 point4;

    public int spawnRate = 100000;
    public int timer = 0;

    public bool isActive = false;

    public int spawnRadius = 5;

    public GameObject bezierCube;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(spawnCube(0, 0, 0, Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)));

        StartCoroutine(ActivateBezier());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isActive) {
            if (timer > spawnRate) {
                StartCoroutine(spawnCube(transform.position.x + Random.Range(-spawnRadius, spawnRadius),
                    transform.position.y,
                    transform.position.z + Random.Range(-spawnRadius, spawnRadius),
                    transform.position.x + Random.Range(-5, 5),
                    transform.position.y,
                    transform.position.z + Random.Range(-5, 5),
                    transform.position.x + Random.Range(-5, 5),
                    transform.position.y,
                    transform.position.z + Random.Range(-5, 5),
                    transform.position.x + Random.Range(-spawnRadius, spawnRadius),
                    transform.position.y + 2.5f,
                    transform.position.z + Random.Range(-spawnRadius, spawnRadius)));
                timer = 0;
            }
            timer++;
        }
        
    }

    IEnumerator ActivateBezier() {
        yield return new WaitForSeconds(3f);
        isActive = true;
    }


    private float getPt2(float p0, float p1, float p2, float t) //bezier algorithm
    {
        return (
            p0 * Mathf.Pow((1 - t), 3) +
            p1 * 3 * t * Mathf.Pow((1 - t), 2) +
            p2 * 3 * Mathf.Pow(t, 2) * (1 - t) +
            p2 * Mathf.Pow(t, 3)
        );
    }

    IEnumerator spawnCube(float x0, float y0, float z0, float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3) {
        float xa, ya, za, xb, yb, zb, xc, yc, zc;
        Vector3 finalPoint = new Vector3();

        point1 = new Vector3(x0, y0, z0);
        point2 = new Vector3(x1, y1, z1);
        point3 = new Vector3(x2, y2, z2);
        point4 = new Vector3(x3, y3, z3);
        GameObject a = null;
        int index = 0;
        for (float i = 0; i < 1; i += 0.02f) {
            xa = getPt2(x0, x1, x2, i);
            ya = getPt2(y0, y1, y2, i);
            za = getPt2(z0, z1, z2, i);
            xb = getPt2(x1, x2, x2, i);
            yb = getPt2(y1, y2, y2, i);
            zb = getPt2(z1, z2, z2, i);
            xc = getPt2(x2, x3, x3, i);
            yc = getPt2(y2, y3, y3, i);
            zc = getPt2(z2, z3, z3, i);
            finalPoint = new Vector3(getPt2(xa, xb, xc, i), getPt2(ya, yb, yc, i), getPt2(za, zb, zc, i));
            yield return new WaitForSeconds(0.03f);
            a = Instantiate(bezierCube, finalPoint, Random.rotation);
            //a.transform.parent = bezierCube.transform;
            index++;
        }
        //Debug.Log("Spawned " + index + " cubes.");
    }
}
