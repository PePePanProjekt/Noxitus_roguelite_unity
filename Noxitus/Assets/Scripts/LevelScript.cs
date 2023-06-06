using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    private int level = 0;

    public TextMeshProUGUI valueText;
    // Start is called before the first frame update
    
    public void SetLvl(int newLvl)
    {
        level = newLvl;
        valueText.text = level.ToString();
    }
}
