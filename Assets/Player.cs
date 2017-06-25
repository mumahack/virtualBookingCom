using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualBookingCom
{
    public class Player : MonoBehaviour, IReturnCall
    {

        private Player player;
        private string destination;
        private double cost;
        private double saved;
        private Item currentItem;
        public GameObject fotoSphere;
        public Material fotoSphereTexture;
        public ShoppingList shoppingList;
        public AudioSource audioSource;
        private Scene currentScene;
        private int decisionCount = 0;
        public SelectionController selectionController;
        //"Items" on his shopping list (Hotel Room, Lunch, Plane Seat class (maybe prices aswell))
        private List<Item> items = new List<Item>();

        // Use this for initialization
        void Start()
        {
            this.play(destination);
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
                this.player.decisionCount = 0;
            }
            return this.player;
        }

        private Player()
        {

        }

        public void play(string destination)
        {
            this.destination = destination;
            this.selectHotel();
        }

        private void selectHotel()
        {
            this.selectionController.ReturnClass = this;
            this.selectionController.GenerateHotelSelector();
            this.fotoSphereTexture.mainTexture = Resources.Load("360Picture/s2 - schleuse") as Texture;
            this.selectionController.SetVisible(true);
        }

        public void returnItemSelected(Item returnItem)
        {
            if (returnItem.title == "Unknown")
            {
                this.returnConfirmItem();
                return;
            }
            this.selectionController.SetVisible(false);
            this.currentItem = returnItem;
            if (currentItem != null && currentItem.scene != null)
            {
                currentItem.scene.SetActive(false);
                currentItem.scene.SetActive(true);
            }
            if (returnItem.type == "Food")
            {
                this.returnConfirmItem();
            }
        }

        public void nextDecision()
        {
            this.decisionCount++;
            switch (decisionCount)
            {
                //Room selection
                case 1:
                    Item[] hotelRooms = new Item[3];
                    hotelRooms[0] = new Item("Small Room", 10, "HotelRoom");
                    hotelRooms[1] = new Item("Medium Room", 1800, "HotelRoom");
                    hotelRooms[2] = new Item("Luxury Room", 2500, "HotelRoom");
                    hotelRooms[0].scene = new Option(fotoSphere, fotoSphereTexture, Resources.Load<Texture>("360Picture/s4a - small hotel"), hotelRooms, hotelRooms[0].title, selectionController, this.audioSource, Resources.Load<AudioClip>("audio/s4a"));
                    hotelRooms[1].scene = new Option(fotoSphere, fotoSphereTexture, Resources.Load<Texture>("360Picture/s4b - big hotel"), hotelRooms, hotelRooms[1].title, selectionController, this.audioSource, Resources.Load<AudioClip>("audio/s4b"));
                    hotelRooms[2].scene = new Option(fotoSphere, fotoSphereTexture, Resources.Load<Texture>("360Picture/s4c - luxury hotel"), hotelRooms, hotelRooms[2].title, selectionController, this.audioSource, Resources.Load<AudioClip>("audio/s4c"));
                    Option roomDisplay = new Option(fotoSphere, fotoSphereTexture, Resources.Load<Texture>("360Picture/s3 - hotel lobby"), hotelRooms, "Choose Room", this.selectionController, this.audioSource, Resources.Load<AudioClip>("audio/s3"));
                    selectionController.DisplayButtonSelector(new SelectionControllerModel(hotelRooms, "Choose Room", false));
                    selectionController.SetVisible(true);
                    roomDisplay.SetActive(true);
                    break;
                case 2:
                    selectionController.GenerateFoodSelector();
                    selectionController.SetVisible(true);
                    selectionController.model.options = new Item[]
                    {
                        new Item("Nothing",0,"Food"),
                        new Item("Bed & Breakfast",20,"Food"),
                        new Item("All inclusive",100,"Food")
                    };
                    new Scene(fotoSphere, fotoSphereTexture, Resources.Load<Texture>("360Picture/s3 - hotel lobby"), this.audioSource, Resources.Load<AudioClip>("audio/s5")).SetActive(true);
                    break;
                case 3:
                    Item[] planeSeats = new Item[3];
                    planeSeats[0] = new Item("Economy", 120, "PlaneSeat");
                    planeSeats[1] = new Item("Business", 400, "PlaneSeat");
                    planeSeats[2] = new Item("First", 930, "PlaneSeat");
                    planeSeats[0].scene = new Option(fotoSphere, fotoSphereTexture, Resources.Load<Texture>("360Picture/s7a - economy"), planeSeats, planeSeats[0].title, selectionController, this.audioSource, Resources.Load<AudioClip>("audio/s7a"));
                    planeSeats[1].scene = new Option(fotoSphere, fotoSphereTexture, Resources.Load<Texture>("360Picture/s7b - business"), planeSeats, planeSeats[1].title, selectionController, this.audioSource, Resources.Load<AudioClip>("audio/s7b"));
                    planeSeats[2].scene = new Option(fotoSphere, fotoSphereTexture, Resources.Load<Texture>("360Picture/s7c - first class"), planeSeats, planeSeats[2].title, selectionController, this.audioSource, Resources.Load<AudioClip>("audio/s7c"));
                    Option seatDisplay = new Option(fotoSphere, fotoSphereTexture, Resources.Load<Texture>("360Picture/s6 - airport lobby"), planeSeats, "Choose Seat", this.selectionController, this.audioSource, Resources.Load<AudioClip>("audio/s6"));
                    selectionController.DisplayButtonSelector(new SelectionControllerModel(planeSeats, "Choose Seat", false));
                    selectionController.SetVisible(true);
                    seatDisplay.SetActive(true);
                    break;
                case 4:
                    this.selectionController.SetVisible(false);
                    new Scene(fotoSphere, fotoSphereTexture, Resources.Load<Texture>("360Picture/s7 - holidays"), this.audioSource, Resources.Load<AudioClip>("audio/s8")).SetActive(true);
                    break;
            }
        }

        public void returnConfirmItem()
        {
            if (this.currentItem != null)
            {
                this.items.Add(this.currentItem);
                this.shoppingList.UpdateList(this.items.ToArray());
            }
            this.nextDecision();
        }
    }
}
