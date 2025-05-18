using UnityEngine;

public class StatueCtrl : BaseMonoBehaviour
{
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            FinishUI.Instance.ShowUI();
        }   
    }
}
