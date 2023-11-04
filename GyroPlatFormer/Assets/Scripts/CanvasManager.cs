using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject[] CurrentCanvases;
    public string[] canvasnames;
    public void ClearActive()
    {
        foreach (GameObject d in CurrentCanvases)
        {
            d.gameObject.SetActive(false);
        }
    }
    public int FindNames(string Names)
    {
        var count = 0;
        foreach(GameObject Ca in CurrentCanvases)
        {
            canvasnames[count] = Ca.name;
            if(Ca.name == Names)
            {
                return count;
            }
            count++;

        }
        Debug.Log(canvasnames);
        return 0;
    }
    public void SwitchCanvas(string CanvasName)
    {
        ClearActive();
        CurrentCanvases[FindNames(CanvasName)].SetActive(true);
    }
}
