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
        this.gameObject.SetActive(this.isShow);
    }
    public virtual void ShowPauseUI()
    {
        this.isShow = true;
        this.gameObject.SetActive(this.isShow);
    }
  
}
