using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoopButtonAnimation1 : MonoBehaviour
{
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();

        transform.DOScale(-0.1f, 1f)
        .SetRelative(true)//その場から↑のDOScaleを動かす
        .SetEase(Ease.OutQuart)//イージングの種類はネット推奨
        .SetLoops(-1, LoopType.Yoyo);//-1で無限ループ化

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
