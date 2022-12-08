using System;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private MassageHudResource massageHudResource;
    [SerializeField] private GameObject popupMassage;
    [SerializeField] private Text massage;

    public void ShowPopup(string massageid)
    {
        massageHudResource.FindItem(massageid, out var massageHud);
        massage.text = massageHud.Massage;
        popupMassage.SetActive(true);
    }

    public void HidePopup()
    {
        massage.text = String.Empty;
        popupMassage.SetActive(false);
    }
}
