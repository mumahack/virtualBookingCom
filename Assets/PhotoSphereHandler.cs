using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoSphereHandler : MonoBehaviour {
    private static Material photoSphere;
    public Material myMaterial;


	// Use this for initialization
	void Start () {
        PhotoSphereHandler.photoSphere = (Material)Resources.Load("360Picture/Materials/SphereView", typeof(Material));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeTexture(Texture newTexture)
    {
        myMaterial.mainTexture = newTexture;
        Debug.Log("Texture changed to: " + newTexture.name);
    }
}
