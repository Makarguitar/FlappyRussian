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
    public float lineDelay = 2f;

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
            string currentLine = dialogueLines[i];

            foreach (char letter in currentLine)
            {
                cutSceneText.text += letter;
                if (currentLine == dialogueLines[3])
                {
                    yield return new WaitForSeconds(0.20f);
                }
                else
                {
                    yield return new WaitForSeconds(letterDelay);
                }
            }

            if (currentLine == dialogueLines[3])
            {
                yield return new WaitForSeconds(5f);
            }
            else
            {
                yield return new WaitForSeconds(lineDelay);
            }


            if (currentLine == dialogueLines[3])
            {
                cutSceneText.text = "";
            }
            else
            {
                for (int j = currentLine.Length; j >= 0; j--)
                {
                    cutSceneText.text = currentLine.Substring(0, j);
                    yield return new WaitForSeconds(0.02f);
                }
            }

            if (currentLine == dialogueLines[2])
            {
                yield return new WaitForSeconds(5f);
            }
            else
            {
                yield return new WaitForSeconds(lineDelay);
            }
        }
    }
}