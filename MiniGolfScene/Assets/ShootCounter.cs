using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootCounter : MonoBehaviour
{
   // Start is called before the first frame update
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
    }

    StrokeManager StrokeManager;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Number of shots : " + StrokeManager.StrokeCount;
    }
}
