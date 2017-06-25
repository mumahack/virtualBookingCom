using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualBookingCom
{
    public class Option : Scene
    {
        ISelectionController selector;
        private SelectionController selectionController;
        private Item[] items;
        private string title;

        public Option(GameObject fotoSphere, Material fotoSphereTexture, Texture skin, Item[] items, string title, SelectionController selectionController, AudioSource audioSource, AudioClip audioClip) : base(fotoSphere, fotoSphereTexture, skin, audioSource, audioClip)
        {
            this.selectionController = selectionController;
            this.items = items;
            this.title = title;
        }

        public new void SetActive(bool active)
        {
            base.SetActive(active);
            if (active)
            {
                selectionController.DisplayButtonSelector(new SelectionControllerModel(items, title, true));
            }
            selectionController.SetVisible(active);
        }
    }
}
