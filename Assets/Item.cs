using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualBookingCom
{
    public class Item
    {
        public static List<Item> allItems = new List<Item>();
        public string title;
        public double price;
        public Option scene;
        public string type;
        
        public Item(string title, double price, string type)
        {
            this.title = title;
            this.price = price;
            this.type = type;
            Item.allItems.Add(this);
        }

    }
}