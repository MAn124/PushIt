using UnityEngine;

public class FinishUI : BaseSingleton<FinishUI>
{
    protected  bool isShow = false;
    protected override void Start()
    {
        base.Start();
        this.HideUI();
    }
    protected virtual void HideUI()
    {
        this.isShow = false;
        Time.timeScale = 1f;
        this.gameObject.SetActive(this.isShow);
    }
    protected virtual void ShowUI()
    {
        this.isShow = true;
        Time.timeScale = 0f;
        this.gameObject.SetActive(this.isShow);
    }
}
