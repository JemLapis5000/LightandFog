using UnityEngine;

public class DisappearOnClick : MonoBehaviour
{
    void OnMouseDown()
    {
        gameObject.SetActive(false);
    }
}
