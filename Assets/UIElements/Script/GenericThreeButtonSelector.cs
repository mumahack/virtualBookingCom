using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericThreeButtonSelector : MonoBehaviour {
    //public string title
    public string title;

    public string option1;
    public string option2;
    public string option3;

    public SelectionController controller;

    // Private Elements
    Transform tranformTitle;
    Transform button1Text, button2Text, button3Text, button4;

	// Use this for initialization
	void Start () {

    }

    private void InitValues()
    {
        tranformTitle = this.transform.Find("Title");
        button1Text = this.transform.Find("Button1/Button1Text");
        button2Text = this.transform.Find("Button2/Button2Text");
        button3Text = this.transform.Find("Button3/Button3Text");
        button4 = this.transform.Find("Button4");
    }
    internal void setText(string title, string button1, string button2, string button3)
    {
        InitValues();
        setTextOfTransform(tranformTitle, title);
        setTextOfTransform(button1Text, button1);
        setTextOfTransform(button2Text, button2);
        setTextOfTransform(button3Text, button3);
    }

    private void setTextOfTransform(Transform title, string v)
    {
        var element = title.GetComponent<TMPro.TextMeshProUGUI>();
        element.text = v;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void pressButton1()
    {
        controller.selectOption(1);
    }

    public void pressButton2()
    {
        controller.selectOption(2);
    }

    public void pressButton3()
    {
        controller.selectOption(3);
    }

    public void pressOK()
    {
        controller.selectOk();
    }

    public void DisplayOkButton(bool display)
    {
        button4.gameObject.SetActive(display);
    }
        
}
