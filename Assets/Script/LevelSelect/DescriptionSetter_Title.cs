using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionSetter_Title : MonoBehaviour
{
    //操作説明のオンオフを確認する。０…非表示、１…表示
    public int DescriptionSet = 0;

    void Update()
    {
        if(DescriptionSet == 0)
            gameObject.GetComponent<UnityEngine.UI.Image>().enabled = false;
        if(DescriptionSet == 1)
            gameObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
    }
}
