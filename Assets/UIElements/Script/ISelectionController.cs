using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualBookingCom;

public interface ISelectionController
{
    void DisplayButtonSelector(SelectionControllerModel model);
    void SetVisible(bool visible);
    void GenerateHotelSelector();
    void GenerateFoodSelector();
}

