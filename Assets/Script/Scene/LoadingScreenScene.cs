using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadingScreenScene
{
    public enum Scene{
        MainMenu, MiloLevel, MiloLevel2, BettyLevel, MomLevel, DadLevel, GortLevel, FinalCutscene, LoadingScene
    }

    public static Scene targetNextScene;

    public static void LoadScene(Scene targetNextScene){
        LoadingScreenScene.targetNextScene = targetNextScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }
    public static void LoaderCallback(){
        SceneManager.LoadScene(targetNextScene.ToString());
    }
}

