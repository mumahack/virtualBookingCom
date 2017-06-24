using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualBookingCom
{
    public class Player : MonoBehaviour
    {

        private Player player;
        private string destination;
        private double cost;
        private double saved;
        //"Items" on his shopping list (Hotel Room, Lunch, Plane Seat class (maybe prices aswell))
        private List<Item> items = new List<Item>();

        // Use this for initialization
        void Start()
        {

        }

        private void Awake()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private Player getPlayer()
        {
            if (!this.player)
            {
                this.player = new Player();
            }
            return this.player;
        }

        private Player()
        {

        }
    }
}
