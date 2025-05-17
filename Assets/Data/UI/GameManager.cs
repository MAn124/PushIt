using UnityEngine;

public class GameManager : BaseMonoBehaviour
{
    [SerializeField] private PauseUI pauseMenuUI;
    protected void FixedUpdate()
    {
        this.OpenPauseMenu();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPauseMenu();
    }
    protected virtual void OpenPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
        
        PauseUI.Instance.ShowPauseUI();
        }
    }
    protected virtual void LoadPauseMenu()
    {
        if (this.pauseMenuUI != null) return;
        this.pauseMenuUI = FindAnyObjectByType<PauseUI>();
    }
}
