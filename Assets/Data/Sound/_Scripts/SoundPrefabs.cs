using System.Collections.Generic;
using UnityEngine;

public class SoundPrefabs : SoundManagerAbstract
{
    [SerializeField] protected List<SoundCtrl> sounds = new();
    protected void Start()
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
        if (this.sounds.Count > 0) return;
        foreach (Transform child in transform)
        {
            SoundCtrl soundCtrl = child.GetComponent<SoundCtrl>();
            if (soundCtrl) this.sounds.Add(soundCtrl);
        }

    }
    protected virtual void HidePrefabs()
    {
        foreach (SoundCtrl soundCtrl in this.sounds)
        {

            soundCtrl.gameObject.SetActive(false);
        }
    }
}
