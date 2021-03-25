using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonAnimation1 : MonoBehaviour
{
   
    public void OnclickAnimation()
    {
        this.transform.DOScale(1.1f, 1.0f).SetEase(Ease.OutFlash,2);
    }
}
