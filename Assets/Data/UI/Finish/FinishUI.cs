using UnityEngine;

public class FinishUI : BaseSingleton<FinishUI>
{
    [SerializeField] protected GameObject finishPanel;
    protected  bool isShow = false;
    protected override void Start()
    {
        base.Start();
        this.HideUI();
    }
    public virtual void HideUI()
    {
        this.isShow = false;
        Time.timeScale = 1f;
        this.finishPanel.SetActive(this.isShow);
    }
    public virtual void ShowUI()
    {
        this.isShow = true;
        Time.timeScale = 0f;
        this.finishPanel.SetActive(this.isShow);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}
