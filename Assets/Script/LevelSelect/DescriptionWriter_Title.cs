using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionWriter_Title : MonoBehaviour
{
    public int WriteOn = 0;

    void Update()
    {
        if (WriteOn == 0)
            gameObject.transform.position = new Vector3(4.0f, 16.5f, 0);
        if (WriteOn == 1)
            gameObject.transform.position = new Vector3(4.0f, 4.5f, 0);
    }
}
