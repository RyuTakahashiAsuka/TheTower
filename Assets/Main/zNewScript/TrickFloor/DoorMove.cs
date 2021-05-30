using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*追加*/
using DG.Tweening;

public class DoorMove : MonoBehaviour
{
  
    public void DoorAnimation()
    {
        this.transform.DOMove(new Vector3(5f, 0, 0), 3f).SetRelative(true);//現在位置から3秒間でX方向に５動かす
    }
   
}
