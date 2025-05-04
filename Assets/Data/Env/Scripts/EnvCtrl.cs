
using System.Collections.Generic;
using UnityEngine;

public class EnvCtrl : BaseMonoBehaviour
{
    [SerializeField] protected List<Transform> envs = new();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnv();
    }
    protected virtual void LoadEnv()
    {
        if (this.envs.Count > 0)
        {
            return;
        }
        foreach (Transform child in transform)
        {
            Transform envCtrl = GetComponent<Transform>();
            this.envs.Add(envCtrl);
        }
    }
}
