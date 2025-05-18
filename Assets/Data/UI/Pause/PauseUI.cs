using UnityEngine;

public class PauseUI : BaseSingleton<PauseUI>
{
    protected bool isShow = false;
    public bool IsShow => isShow;
    protected override void Start()
    {
        base.Start();
        this.HidePauseUI();
    }
  
    public virtual void HidePauseUI()
    {
        this.isShow = false;
        Time.timeScale = 1f;
        this.gameObject.SetActive(this.isShow);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public virtual void ShowPauseUI()
    {
        this.isShow = true;
        Time.timeScale = 0f;
        this.gameObject.SetActive(this.isShow);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
  
}
