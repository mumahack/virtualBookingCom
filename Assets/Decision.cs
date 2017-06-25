using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : Scene
{
    public ISelectionController selector;

    public new void SetActive(bool active)
    {
        base.SetActive(active);
        selector.SetVisible(active);
    }

    public Decision(GameObject fotoSphere, Material fotoSphereTexture, Texture skin) : base(fotoSphere, fotoSphereTexture, skin, null, null)
    {
        this.selector = new SelectionController();
    }
}
