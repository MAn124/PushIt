using UnityEngine;

public class StartUI : BaseSingleton<StartUI>
{
    protected bool isShow = false;
    protected override void Start()
    {
        base.Start();
        this.ShowStartMenu();
    }
    public virtual void ShowStartMenu()
    {
        this.isShow = true;
        this.gameObject.SetActive(this.isShow);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public virtual void HideStartMenu()
    {
        this.isShow = false;
        this.gameObject.SetActive(this.isShow);
        Time.timeScale = 1f;
    }
}
