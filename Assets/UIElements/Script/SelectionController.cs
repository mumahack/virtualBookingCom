
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualBookingCom;

public class SelectionController : MonoBehaviour, ISelectionController, IReturnCall
{
    public GameObject Hotelselector;
    public GameObject Foodselector;
    public GameObject Button3Selector;
    public Vector3 defaultPosition;
    public Quaternion defaultRotation;

    private int selectionStatus;
    public IReturnCall ReturnClass;

    public static readonly string[] roomSelector = {
        "Room Size",
        "Small",
        "Huge",
        "I buy that shit" };

    public static readonly string[] airportSelector = {
        "Airport",
        "Economy",
        "Business",
        "First Class" };
    public SelectionControllerModel model;

    private GameObject displayObject;


    // Use this for initialization
    void Start () {
        //TestMe();
    }

    void TestMe()
    {
        selectionStatus = 1;
        this.ReturnClass = this;
        CallSelection(selectionStatus);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CallSelection(int step)
    {
        // For the beginning always 3 button
        switch(step) {
            case 1:
                GenerateHotelSelector();
                break;

            case 2:
                GenerateButtonSelector(roomSelector,false);
                break;

            case 3:
                GenerateButtonSelector(roomSelector, true);
                break;

            case 4:
                GenerateFoodSelector();
                break;

            case 5:
                GenerateButtonSelector(airportSelector, false);
                break;

            case 6:
                GenerateButtonSelector(airportSelector, true);
                break;
        }
    }

    public void selectOk()
    {
        ReturnClass.returnConfirmItem();
    }

    public void selectOption(int v) {

        if (model == null || model.options[v - 1] == null)
            ReturnClass.returnItemSelected(
                new Item("Unknown", 0, "unknown"));
        else
            ReturnClass.returnItemSelected(model.options[v - 1]);
    }

    public void GenerateFoodSelector()
    {
        var ret = GenerateDisplayObject(Foodselector);
        var selector = ret.GetComponent<GenericThreeButtonSelector>();
        selector.controller = this;
    }

    public void GenerateHotelSelector()
    {
        var ret = GenerateDisplayObject(Hotelselector);
        var selector = ret.GetComponent<GenericThreeButtonSelector>();
        selector.controller = this;
    }

    public void GenerateButtonSelector(string[] selectorValues, bool displayOkButton)
    {
        /*
        var ret = GenerateDisplayObject(Button3Selector);
        var selector = ret.GetComponent<GenericThreeButtonSelector>();
        selector.setText(title: selectorValues[0], button1: selectorValues[1], button2: selectorValues[2], Button3Selector: selectorValues[3]);
        selector.DisplayOkButton(displayOkButton);
        selector.controller = this;*/

        var newModel = new SelectionControllerModel(
            new Item[] {
            new Item(selectorValues[0], 0.00, "type"),
            new Item(selectorValues[1], 0.00, "type"),
            new Item(selectorValues[2], 0.00, "type")
                },
            selectorValues[0],
            displayOkButton
            );
        DisplayButtonSelector(newModel);
    }

    /*
    public void DisplayButtonSelector(SelectionControllerModel model)
    {
        this.model = model;
        UpdateDisplayByModel(model);
    }*/

    public void DisplayButtonSelector(SelectionControllerModel model)
    {
        var ret = GenerateDisplayObject(Button3Selector);
        var selector = ret.GetComponent<GenericThreeButtonSelector>();
        selector.setText(
            title: model.title,
            button1: GetOptionText(0),
            button2: GetOptionText(1),
            button3: GetOptionText(2));

        this.model = model;
        selector.DisplayOkButton(model.showOK);
        selector.controller = this;
    }

    private GameObject GenerateDisplayObject(GameObject obj)
    {
        if (displayObject != null)
        {
            displayObject.SetActive(false);
            Destroy(displayObject);
        }


        displayObject = Instantiate(obj, defaultPosition, defaultRotation);

        return displayObject;
    }

    private string GetOptionText(int v)
    {
        if (model == null || model.options == null || model.options.Length <= v)
            return "undefined";

        return model.options[v].title;
    }

    public void SetVisible(bool visible)
    {
        if (displayObject != null)
            displayObject.SetActive(visible);
    }

    public void returnItemSelected(Item returnItem)
    {
        this.selectionStatus++;
        CallSelection(selectionStatus);
    }

    public void returnConfirmItem()
    {
        this.selectionStatus++;
        CallSelection(selectionStatus);
    }
}
