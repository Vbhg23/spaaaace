using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void ZahlopnutGame() {
        Application.Quit();
    }
    public void PereigratLevel() {
        SceneManager.LoadSceneAsync(SceneID.gameSceneID);
    }
}
