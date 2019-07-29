using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescenetest : MonoBehaviour
{
    SaveAndLoad saveAndLoad;

    private void Start()
    {
        saveAndLoad = FindObjectOfType<SaveAndLoad>();
    }

    public void ChangeScene()
    {
        saveAndLoad.SaveGame();
        SceneManager.LoadScene("DiplomacyWar");
    }
}
