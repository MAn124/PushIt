using UnityEngine;

public class BaseMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponent();
    }
    protected virtual void Start()
    {

    }
    protected virtual void Reset()
    {
        this.LoadComponent();
    }
    protected virtual void LoadComponent()
    {

    }
    protected virtual void ResetValue()
    {

    }
}
