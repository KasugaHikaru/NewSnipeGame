using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScreen : MonoBehaviour
{

    //Secen
    public void GotoTitleScene()
    {
        GameManager.instance.ChangeScene("Title");
    }
    public void GotoGameScene()
    {
        GameManager.instance.ChangeScene("Game");
    }
    public void GotoResultScene()
    {
        GameManager.instance.ChangeScene("Result");
    }

    //Screen
    public void GotoChoiceWeponScreen()
    {
        GameManager.instance.ChangeScreen("ChoiceWepon");
    }
    public void GotoGameSettingScreen()
    {
        GameManager.instance.ChangeScreen("GameSetting");
    }



}
