using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDAnim : MonoBehaviour
{
    // This method will be called by the animation event
    public void HideGameObject()
    {
        // Make the GameObject invisible
        gameObject.SetActive(false);
    }
}
