using UnityEngine;

public class BtnPlayGame : BtnAbstract
{
    protected override void OnClick()
    {
        this.PlayGame();
    }
    protected virtual void PlayGame()
    {
        StartUI.Instance.HideStartMenu();
    }
}
