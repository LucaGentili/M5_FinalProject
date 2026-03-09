using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Win : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _canvas.enabled = true;
        }
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("UI_Scene");
    }

    public void OnClickRestart()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexScene);
    }
}
