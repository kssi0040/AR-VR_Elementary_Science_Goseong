using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    public RectTransform Capture;
    public RectTransform Contents;
    public RectTransform BackGroundCanvas;
    public TextManager manager;
    public Transform WebCam;
    //public Transform ARcore;
    
	// Use this for initialization
	void Start ()
    {
        if (manager.currentStage == 2)
        {
            BackGroundCanvas.transform.gameObject.SetActive(true);
            Capture.transform.gameObject.SetActive(false);
            Contents.transform.gameObject.SetActive(true);
            WebCam.transform.gameObject.SetActive(false);
            //ARcore.transform.gameObject.SetActive(false);
        }
        else
        {
            Capture.transform.gameObject.SetActive(false);
            Contents.transform.gameObject.SetActive(true);
            WebCam.transform.gameObject.SetActive(false);
            //ARcore.transform.gameObject.SetActive(false);
        }
	}
	
    public void CaptureOn()
    {
        if (manager.currentStage == 2)
        {
            BackGroundCanvas.transform.gameObject.SetActive(false);
            Capture.transform.gameObject.SetActive(true);
            Contents.transform.gameObject.SetActive(false);
            WebCam.transform.gameObject.SetActive(true);
            //ARcore.transform.gameObject.SetActive(true);
            GameObject.Find("CaptureManager").GetComponent<TakeCapture>().TakeShotWithKids(GameObject.Find("CaptureManager").GetComponent<TakeCapture>().Kids, true);
        }
        else
        {
            Capture.transform.gameObject.SetActive(true);
            Contents.transform.gameObject.SetActive(false);
            WebCam.transform.gameObject.SetActive(true);
            //ARcore.transform.gameObject.SetActive(true);
            GameObject.Find("CaptureManager").GetComponent<TakeCapture>().TakeShotWithKids(GameObject.Find("CaptureManager").GetComponent<TakeCapture>().Kids, true);
        }
       
    }

    public void CaptureOff()
    {
        if (manager.currentStage == 2)
        {
            BackGroundCanvas.transform.gameObject.SetActive(true);
            Capture.transform.gameObject.SetActive(false);
            Contents.transform.gameObject.SetActive(true);
            WebCam.transform.gameObject.SetActive(false);
            //ARcore.transform.gameObject.SetActive(false);
            GameObject.Find("CaptureManager").GetComponent<TakeCapture>().TakeShotWithKids(GameObject.Find("CaptureManager").GetComponent<TakeCapture>().Kids, false);
        }
        else
        {
            Capture.transform.gameObject.SetActive(false);
            Contents.transform.gameObject.SetActive(true);
            WebCam.transform.gameObject.SetActive(false);
            //ARcore.transform.gameObject.SetActive(false);
            GameObject.Find("CaptureManager").GetComponent<TakeCapture>().TakeShotWithKids(GameObject.Find("CaptureManager").GetComponent<TakeCapture>().Kids, false);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
