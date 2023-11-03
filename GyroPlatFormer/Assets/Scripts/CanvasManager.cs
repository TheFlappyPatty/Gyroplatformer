using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject[] CurrentCanvases;
    public void ClearActive()
    {
        foreach (GameObject d in CurrentCanvases)
        {
            d.gameObject.SetActive(false);
        }
    }
    public void SwitchCanvas(int Active)
    {
        ClearActive();
        CurrentCanvases[Active].SetActive(true);
    }
}
