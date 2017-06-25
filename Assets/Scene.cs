using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene {
    public GameObject fotoSphere;
    public Material fotoSphereTexture;
    public Texture skin;
    public AudioSource audioSource;
    public AudioClip audioClip;
    protected bool active = false;

    public void ToggleActive()
    {
        this.active = !this.active;
        this.SetActive(this.active);
    }

    public void SetActive(bool active)
    {
        this.active = active;
        if (this.active)
        {
            fotoSphereTexture.mainTexture = skin;
            Debug.Log("Texture changed to: " + skin.name);
            fotoSphere.SetActive(this.active);
            this.audioSource.clip = this.audioClip;
            this.audioSource.Play();
        }
        else
        {
            fotoSphereTexture.mainTexture = null;
            fotoSphere.SetActive(this.active);
        }
    }

    public Scene(GameObject fotoSphere, Material fotoSphereTexture, Texture skin, AudioSource audioSource, AudioClip audioClip)
    {
        this.fotoSphere = fotoSphere;
        this.fotoSphereTexture = fotoSphereTexture;
        this.skin = skin;
        this.audioSource = audioSource;
        this.audioClip = audioClip;
    }
}
