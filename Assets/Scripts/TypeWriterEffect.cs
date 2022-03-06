using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TypeWriterEffect : MonoBehaviour
{
    public float delaySpeed = 0.01f;
    [TextArea]
    public string fullText;
    public bool textCompleted = false;
    private string currentText;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (i = 0; i < fullText.Length + 1; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<TMP_Text>().text = currentText;
            if (i == fullText.Length)
            {
                textCompleted = true;
            }
            yield return new WaitForSeconds(delaySpeed);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && textCompleted) // Custom code to advance scene
        {
            SceneManager.LoadScene("InstructionsScreen");

        }


        if (Input.anyKey)
        {
                currentText = fullText;
                this.GetComponent<TMP_Text>().text = currentText;
                i = fullText.Length;
                textCompleted = true;
            
           
        }

       
    }
}
