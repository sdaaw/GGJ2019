using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pickedUpImg;

    public static GameManager GM;

    private void Awake()
    {
        GM = this;
    }

    public void ShowPickedImg(Sprite sp)
    {
        pickedUpImg.GetComponent<Image>().sprite = sp;
        StartCoroutine(showImg());
    }

    private IEnumerator showImg()
    {
        //TODO: add cool effect :)
        pickedUpImg.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        pickedUpImg.gameObject.SetActive(false);
    }
}
