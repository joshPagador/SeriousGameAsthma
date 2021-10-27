using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField]
    private ColorBlock new_color_setting;

    public bool isCorrectOption = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (GetComponent<Button>().colors == new_color_setting)
        //{
        //    return;
        //}
        
        //green color
        if (isCorrectOption)
        {
            new_color_setting = GetComponent<Button>().colors;
            new_color_setting.pressedColor = Color.green;

            GetComponent<Button>().colors = new_color_setting;
        }
        //red color
        else if(!isCorrectOption)
        {
            new_color_setting = GetComponent<Button>().colors;
            new_color_setting.pressedColor = Color.red;

            GetComponent<Button>().colors = new_color_setting;
        }
    }
}
