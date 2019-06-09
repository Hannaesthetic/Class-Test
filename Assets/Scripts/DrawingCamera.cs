using UnityEngine;
using UnityEngine.UI;

public class DrawingCamera : MonoBehaviour
{
    public GameObject[] pages;
    public Camera drawingCamera;
    public Transform canvasParent;

    private RawImage overlayImage;
    private int page;

    void Start()
    {
        foreach (GameObject p in pages)
        {
            p.SetActive(false);
        }
        SetPage(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (page + 1 >= pages.Length)
            {
                //finish
            } else
            {
                SetPage(page + 1);
            }
        }
    }

    void SetPage(int newPage)
    {
        if (overlayImage != null)
        {
            pages[page].GetComponent<Animator>().enabled = true;
        }
        page = newPage;
        pages[page].SetActive(true);
        overlayImage = pages[page].GetComponentInChildren<RawImage>();
        overlayImage.enabled = true;
        drawingCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        overlayImage.texture = drawingCamera.targetTexture;
    }
}