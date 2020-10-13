using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyPanelResultPanel : MonoBehaviour
{
    [SerializeField] private GameObject _actyalPartyPanel;
    private ParticipantСell[] _actyalParty;
    private ParticipantСell[] _party;

    public void SetActualPartyPanel()
    {
        _actyalParty = _actyalPartyPanel.GetComponentsInChildren<ParticipantСell>();
        _party = GetComponentsInChildren<ParticipantСell>();

        for (int i = 0; i < _party.Length; i++)
        {
            _party[i].SetData(_actyalParty[i].GetNumberPoints(), _actyalParty[i].GetName());
            //_party[i].GetComponent<Image>().sprite = _actyalParty[i].GetComponent<Image>().sprite;
        }

    }
}
