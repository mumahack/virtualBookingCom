using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualBookingCom {
    public class SelectionControllerModel {
        public Item[] options;
        public string title;
        public bool showOK;

        public SelectionControllerModel(Item[] options, string title, bool showOK)
        {
            this.options = options;
            this.title = title;
            this.showOK = showOK;
        }
    }
}
