using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishline : MonoBehaviour
{
    [Tooltip("Put the name of the Scene you want to load here")]
    public string SceneName;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
