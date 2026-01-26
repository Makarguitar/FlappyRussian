using System.Collections;
using TMPro;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    public TextMeshProUGUI cutSceneText;

    public string[] dialogueLines =
    {
        "You are a lonely Alkash that is trying to stop drinking...",
        "you are coming back from a grocery store but its already 11pm!",
        "you have to try avoid all of the night clubs, because if you will enter them...",
        "you are not coming back...",
    };

    public float letterDelay = 0.05f;
    public float lineDelay = 1f;
    
    void Start()
    {
        StartCoroutine(ShowText());
    }

    void Update()
    {
        
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < dialogueLines.Length; i++)
        {
            cutSceneText.text = "";
            string firstLine = dialogueLines[i];

            foreach (char letter in firstLine)
            {
                cutSceneText.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
