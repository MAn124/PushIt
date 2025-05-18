using UnityEngine;

public class BtnExit : BtnAbstract
{
    protected override void OnClick()
    {
        this.ExitGame();
    }
    protected virtual void ExitGame()
    {
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
