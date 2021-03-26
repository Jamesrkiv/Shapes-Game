using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundResizer : MonoBehaviour
{
    public GameObject backgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform bck = backgroundImage.GetComponent<RectTransform>(); // Gets 2d transform component
        Vector2 size = new Vector2(Screen.width, ((Screen.width / 16) * 9)); // Creates 16:9 vector2
        bck.sizeDelta = size; 
    }
}
