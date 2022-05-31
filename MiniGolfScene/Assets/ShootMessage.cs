using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        GetComponent<Text>().text = "";
    }

    StrokeManager StrokeManager;

    // Update is called once per frame
    void Update()
    {
        if(StrokeManager.StrokeMode == StrokeManager.StrokeModeEnum.READY_TO_HIT )
        {
            GetComponent<Text>().text = "READY TO SHOOT !";
        }
    }
}
