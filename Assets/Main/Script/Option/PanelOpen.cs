using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelOpen : MonoBehaviour
{
    [SerializeField]
    private GameObject SettingPanel;

    void Start()
    {
      SettingPanel.transform.localScale = Vector3.zero;    
    }
    public void SettingOpen()
    {
        SettingPanel.transform.DOScale(1f, 1f);
    }
    
}
