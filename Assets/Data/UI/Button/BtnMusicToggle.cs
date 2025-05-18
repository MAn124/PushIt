using UnityEngine;

public class BtnMusicToggle : BtnAbstract
{
    protected override void OnClick()
    {
        SoundManagerCtrl.Instance.ToggleMusic();
    }
}
