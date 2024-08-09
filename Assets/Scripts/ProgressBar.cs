using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{

    public GameObject innerBar; 
    public float maxValue;
    public float outerBarWidth;
    private Vector2 innerSizeDelta;
    private Vector2 innerAchoredPosition;

    // Start is called before the first frame update
    void Start()
    {
        outerBarWidth = gameObject.GetComponent<RectTransform>().sizeDelta.x;

        changeProgressBarVal(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeProgressBarVal(float currentVal){

        innerAchoredPosition = innerBar.GetComponent<RectTransform>().anchoredPosition;
        innerAchoredPosition.x = ((-outerBarWidth) + (currentVal / maxValue) * outerBarWidth) / 2;
        innerBar.GetComponent<RectTransform>().anchoredPosition = innerAchoredPosition;

        innerSizeDelta = innerBar.GetComponent<RectTransform>().sizeDelta;
        innerSizeDelta.x = (currentVal / maxValue) * outerBarWidth;
        innerBar.GetComponent<RectTransform>().sizeDelta = innerSizeDelta;
    }
}
