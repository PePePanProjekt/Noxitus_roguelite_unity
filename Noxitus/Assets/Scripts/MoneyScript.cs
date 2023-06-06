using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    private int value = 0;

    public TextMeshProUGUI valueText;
    // Start is called before the first frame update
    
    public void SetMoney(int newValue)
    {
        value = newValue;
        valueText.text = value.ToString();
    }
}
