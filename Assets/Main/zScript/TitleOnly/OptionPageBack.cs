using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OptionPageBack : MonoBehaviour
{
    [SerializeField]
    private GameObject OptionPanel;//オプションのパネル
    [SerializeField]
    private GameObject OperationPanel;//操作説明のパネル

    
    public void SettingBack()
    {
        /*二つのパネルを同時に閉じる*/
        OptionPanel.transform.DOScale(0f, 0.7f);
        OperationPanel.transform.DOScale(0f, 0.7f);
    }
}
