using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraController : MonoBehaviour
{



    Assets.Pixelation.Scripts.Pixelation pixelboi;
    UnityStandardAssets.ImageEffects.ScreenSpaceAmbientOcclusion occlusion;
    UnityStandardAssets.ImageEffects.Twirl twirl;
    Assets.Pixelation.Scripts.Chunky chunky;

    public int moveAmount = 2;
    private Vector3 originalLocation = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
        chunky = GetComponent<Assets.Pixelation.Scripts.Chunky>();
        pixelboi = GetComponent<Assets.Pixelation.Scripts.Pixelation>();
        occlusion = GetComponent<UnityStandardAssets.ImageEffects.ScreenSpaceAmbientOcclusion>();
        twirl = GetComponent<UnityStandardAssets.ImageEffects.Twirl>();
        pixelboi.BlockCount = 0;
        originalLocation = transform.position;

        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(originalLocation, new Vector3(originalLocation.x + Random.Range(-moveAmount, moveAmount), 
            originalLocation.y + Random.Range(-moveAmount, moveAmount), 
            originalLocation.z + Random.Range(-moveAmount, moveAmount)), Time.deltaTime);



    }

    IEnumerator RandomOcclusion() {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 100; i++) {

            occlusion.m_Radius = Mathf.Sin(i / 2) * 1.2f;
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(RandomOcclusion());
    }

    IEnumerator FinishFade() {

        chunky.enabled = !chunky.enabled;
        yield return new WaitForSeconds(0.5f);
        chunky.enabled = !chunky.enabled;
        yield return new WaitForSeconds(0.2f);
        chunky.enabled = !chunky.enabled;
        yield return new WaitForSeconds(1f);
        chunky.enabled = !chunky.enabled;
        yield return new WaitForSeconds(0.2f);
        chunky.enabled = !chunky.enabled;
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 100; i++) {
            chunky.Color.r -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");

    }


    IEnumerator FadeIn() {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 512; i++) {
            pixelboi.BlockCount+= Mathf.Sin(i) + 1;
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(RandomOcclusion());
    }

    IEnumerator FadeOut() {
        yield return new WaitForSeconds(20f);
        StartCoroutine(FinishFade());


    }
}
