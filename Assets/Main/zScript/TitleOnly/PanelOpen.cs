using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelOpen : MonoBehaviour
{
    [Header("UI類")]
    [SerializeField]
    private GameObject ThisPanel;//開くパネル

    void Start()
    {
      ThisPanel.transform.localScale = Vector3.zero;//パネルを表示させない為、Scaleの初期値を0に設定    
    }
    public void SettingOpen()
    {
        ThisPanel.transform.DOScale(1f, 1f);//パネルを1秒かけてScaleを1にする
    }
    
}
