using UnityEngine;

public class BtnClosePauseMenu : BtnAbstract
{
    public virtual void ClosePauseUI()
    {
        PauseUI.Instance.HidePauseUI();
    }
    protected override void OnClick()
    {
        this.ClosePauseUI();
    }
}
