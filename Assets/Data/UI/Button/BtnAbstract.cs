using UnityEngine;
using UnityEngine.UI;

public abstract class BtnAbstract : BaseMonoBehaviour
{
    [SerializeField] protected Button button;
    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadButton();
    }
    protected virtual void LoadButton()
    {
        if(this.button != null) return;
        this.button = GetComponent<Button>();
    }
    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }
    protected abstract void OnClick();
}
