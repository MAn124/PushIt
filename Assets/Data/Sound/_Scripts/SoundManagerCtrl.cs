using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManagerCtrl : BaseMonoBehaviour
{
    [SerializeField] protected SoundPrefabs soundPrefabs;
    [SerializeField] protected SoundSpawner soundSpawner;
    [SerializeField] protected MusicCtrl musicCtrl;
    [SerializeField] protected SoundName bgName = SoundName.Idea10;
    [SerializeField] protected SoundName sFXName = SoundName.ExplosionSound;
    [Range(0f, 1f)]
    [SerializeField] protected float musicVolume = 1f;
    [Range(0f, 1f)]
    [SerializeField] protected float SFXVolume = 1f;
    [SerializeField] protected List<MusicCtrl> listMusic;
    [SerializeField] protected List<SFXCtrl> listSFX;

    public SoundPrefabs SoundPrefabs => soundPrefabs;
    public SoundSpawner SoundSpawner => soundSpawner;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    protected override void Start()
    {
        base.Start();
        //this.LoadBmg();
    }
    protected virtual void FixedUpdate()
    {
        this.VolumeMusicUpdate();
        this.VolumeSFXUpdate();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
        this.LoadSpawner();
    }
    protected virtual void LoadPrefabs()
    {
        if (this.soundPrefabs != null) return;
        this.soundPrefabs = GetComponentInChildren<SoundPrefabs>();
    }
    protected virtual void LoadSpawner()
    {
        if (this.soundSpawner != null) return;
        this.soundSpawner = GetComponentInChildren<SoundSpawner>();
    }
    protected virtual void LoadBmg()
    {
        if (this.musicCtrl == null) this.musicCtrl = this.CreatBgm(this.bgName);
        this.musicCtrl.gameObject.SetActive(true);
    }
    protected virtual MusicCtrl CreatBgm(SoundName name)
    {
       MusicCtrl prefab = (MusicCtrl) this.soundPrefabs.GetByName(this.bgName.ToString());
       return  this.CreatBgm(prefab);
    }
    protected virtual MusicCtrl CreatBgm(MusicCtrl prefab)
    {
        MusicCtrl musicCtrl = (MusicCtrl) this.soundSpawner.Spawn(prefab);
        this.AddMusic(musicCtrl);
        return musicCtrl;
    }
    protected virtual void AddMusic(MusicCtrl musicCtrl)
    {
        if (this.listMusic.Contains(musicCtrl)) return;
        this.listMusic.Add(musicCtrl);
    }
    public virtual SFXCtrl CreatSFX(SoundName name)
    {
        SFXCtrl prefab = (SFXCtrl)this.soundPrefabs.GetByName(this.sFXName.ToString());
        return this.CreatSFX(prefab);
    }
    protected virtual SFXCtrl CreatSFX(SFXCtrl prefab)
    {
        SFXCtrl musicCtrl = (SFXCtrl)this.soundSpawner.Spawn(prefab);
        this.AddSFX(musicCtrl);
        return musicCtrl;
    }
    protected virtual void AddSFX(SFXCtrl sfxCtrl)
    {
        if (this.listSFX.Contains(sfxCtrl)) return;
        this.listSFX.Add(sfxCtrl);
    }
    protected virtual void ToggleMusic()
    {
        if (this.musicCtrl == null)
        {
            this.LoadBmg();
            return;
        }
        bool status = this.musicCtrl.gameObject.activeSelf;
        this.musicCtrl.gameObject.SetActive(!status);
    }
    protected virtual void VolumeMusicUpdate()
    {
       foreach(MusicCtrl musicCtrl in this.listMusic)
        {
            musicCtrl.AudioSource.volume = this.musicVolume;
        }
    }
    protected virtual void VolumeSFXUpdate()
    {
        foreach (SFXCtrl sfxCtrl in this.listSFX)
        {
            sfxCtrl.AudioSource.volume = this.musicVolume;
        }
    }
}
