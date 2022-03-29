using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceScene : MonoBehaviour
{
    [SerializeField] bool anyKeyToAdvance = true;
    [SerializeField] bool spaceToAdvance;
    [SerializeField] bool returnToAdvance;

    [SerializeField] public string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void NextScene()
    {
        FindObjectOfType<AudioManager>().Play("MenuClick");
        SceneManager.LoadScene(nextSceneName);
    }

    private void Update()
    {
        if (Input.anyKey && anyKeyToAdvance)
        {
            NextScene();
        }
        if (Input.GetKeyDown(KeyCode.Space) && spaceToAdvance)
        {
            NextScene();
        }
        if (Input.GetKeyDown(KeyCode.Return) && returnToAdvance)
        {
            NextScene();
        }

    }
}
