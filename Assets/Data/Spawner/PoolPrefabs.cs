using System.Collections.Generic;
using UnityEngine;

public class PoolPrefabs<T> : BaseMonoBehaviour where T : MonoBehaviour
{

    [SerializeField] protected List<T> prefabs = new();
    protected override void Awake()
    {
        this.HidePrefabs();

    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
    }
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        foreach (Transform child in transform)
        {
            T prefab = child.GetComponent<T>();
            if (prefab) this.prefabs.Add(prefab);
        }
    }
    protected virtual void HidePrefabs()
    {
        foreach (T prefab in this.prefabs)
        {

            prefab.gameObject.SetActive(false);
        }
    }
    public virtual T GetByName(string name)
    {
        foreach (T prefab in this.prefabs)
        {
            if (prefab.name != name) continue;
            return prefab;
        }
        return null;
    }
}
