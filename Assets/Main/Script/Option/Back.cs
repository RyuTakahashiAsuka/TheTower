using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Back : MonoBehaviour
{
    [SerializeField]
    private GameObject SettingPanel1;
    [SerializeField]
    private GameObject SettingPanel2;

    
    public void SettingBack()
    {
        SettingPanel1.transform.DOScale(0f, 1f);
        SettingPanel2.transform.DOScale(0f, 1f);
    }
}
