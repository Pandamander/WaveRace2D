using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterUI : MonoBehaviour
{

    [SerializeField] private int currentValue = 0;
    [SerializeField] private Sprite[] states;

    // Start is called before the first frame update
    public void ChangeCurrentValue(int num)
    {
        currentValue = num;

        if (num < states.Length && num >= 0)
        {
            UpdateStates();
        }
        else
        {
            Debug.LogError("Out of range value passed to MeterUI: " + num);
        }
    }

    // Update is called once per frame
    void UpdateStates()
    {
        GetComponent<Image>().sprite = states[currentValue];
    }
}
