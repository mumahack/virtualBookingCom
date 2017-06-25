using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieveData : MonoBehaviour
{

    string username = "b_munich_hackers17";
    string password = "f7u@9prYLjCZq,w]2Gd[";

    public void Start()
    {
        GetHotels("Munich");
    }

    public void GetHotels(string city)
    {
        var url = "distribution-xml.booking.com/json/bookings.getCities?" + city;
        var connector = new WWW("https://" +
            WWW.EscapeURL(username) + ":" +
            WWW.EscapeURL(password) + "@" +
            url
            );

        var dt = connector.text;
    }

}
