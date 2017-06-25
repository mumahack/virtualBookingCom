using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualBookingCom;

public class ShoppingList : MonoBehaviour {
    List<Transform> lines;
    Transform sum;
    public bool testenabled = false;

	// Use this for initialization
	void Start () {
        InitLines();
        ClearAllLines();

        if (testenabled == true)
            importTestData();
	}

    private void importTestData()
    {
        var list = new Item[] {
            new Item("Luxuary Room", 520.10, "Hotel"),
            new Item("Bed and Breakfast", 20.10, "Eat"),
            new Item("Flight Fist Class", 3320.10, "Flight")
        };

        UpdateList(list);

    }

    public void UpdateList(Item[] list)
    {
        int line = 0;
        double newSum = 0;

        foreach(var entry in list)
        {
            SetLine(lines[line], entry.title, entry.price);
            newSum += entry.price;
            line++;
        }

        SetLine(sum, "Sum", newSum);

    }

    private void ClearAllLines()
    {
        foreach(var entry in lines)
        {
            ClearLine(entry);
        }
        ClearSum();
    }

    private void ClearSum()
    {
        SetLine(sum, "Sum", 0f);
    }

    private void ClearLine(Transform entry)
    {
        SetLine(entry, null, 0);
    }

    private void SetLine(Transform entry, string element, double price)
    {
        string priceText = string.Format("{0:0.00} €", price);

        if (string.IsNullOrEmpty(element))
        {
            priceText = "";
            element = "";
        }

        var textTransform = entry.Find("Left");
        var priceTransform = entry.Find("Right");

        textTransform.GetComponent<TMPro.TextMeshProUGUI>()
            .text = element;
        

        priceTransform.GetComponent<TMPro.TextMeshProUGUI>()
            .text = priceText;
     
    }

    void InitLines()
    {
        int counter = 1;
        lines = new List<Transform>();
        do
        {
            string objectname = string.Format("Line{0}", counter);
            var trans = this.transform.Find(objectname);
            if (trans == null)
                break;

            lines.Add(trans);

            counter++;

        } while (true);
        sum = this.transform.Find("Summe");
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
