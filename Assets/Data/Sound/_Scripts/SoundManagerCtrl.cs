using UnityEngine;

public class SoundManagerCtrl : BaseMonoBehaviour
{
    [SerializeField] protected SoundPrefabs soundPrefabs;
    [SerializeField] protected SoundSpawner soundSpawner;
    [SerializeField] protected SoundName bgName = SoundName.Idea10;
    [SerializeField] protected MusicCtrl musicCtrl;
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
        this.LoadBmg();
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
        if (this.musicCtrl == null) this.musicCtrl = this.CreatBgm();
        this.musicCtrl.gameObject.SetActive(true);
    }
    protected virtual MusicCtrl CreatBgm()
    {
       MusicCtrl prefab = (MusicCtrl) this.soundPrefabs.GetByName(this.bgName.ToString());
       return (MusicCtrl) this.soundSpawner.Spawn(prefab);
    }
}
