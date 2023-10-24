using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    public void AgainButton()
    {
        GamePause.Instance.Resume();
        SceneManager.LoadScene(1);
    }
    public void HomeButton()
    {
        GamePause.Instance.Resume();
        SceneManager.LoadScene(0);
    }
    public void NextLVButton()
    {
        GamePause.Instance.Resume();
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuButton()
    {
        GamePause.Instance.PauseGame();
    }

    public void CloseMenuButton()
    {
        GamePause.Instance.Resume();
    }
}
