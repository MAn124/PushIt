using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPlayAgain : BtnAbstract
{
    protected override void OnClick()
    {
        this.Restart();
    }
    protected virtual void Restart()
    {
        Time.timeScale = 1.0f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
