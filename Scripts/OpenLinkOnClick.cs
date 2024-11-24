using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinkOnClick : MonoBehaviour
{
    public string url; // Make sure this is public

    void OnMouseDown()
    {
        Application.OpenURL(url);
    }
}
