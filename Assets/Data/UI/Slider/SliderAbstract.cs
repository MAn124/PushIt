using UnityEngine;
using UnityEngine.UI;

public abstract class SliderAbstract : BaseMonoBehaviour
{
    [SerializeField] protected Slider slider;
    protected override void Start()
    {
        base.Start();
        this.slider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
    }
    protected virtual void LoadSlider()
    {
        if (slider != null) return;
        this.slider = GetComponent<Slider>();
    }
    protected virtual void OnSliderValueChanged(float value)
    {

    }
}
