using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    public TextMeshProUGUI cutSceneText;
    public Image blackBg;
    public Image skyBg;
    public float fadeDuration = 2f;
    public Animator alkashAnimator;
    public GameObject mapFront;
    public GameObject mapBack;
    public GameObject street;

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
                yield return new WaitForSeconds(2f);
                cutSceneText.CrossFadeColor(Color.darkRed, 3f, true, true);
                yield return new WaitForSeconds(3f);
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

        float time = 0f;
        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);
            blackBg.color = new Color(0, 0, 0, alpha);
            time += Time.deltaTime;
            yield return null;
        }
        
        blackBg.gameObject.SetActive(false);
        alkashAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(4f);
        mapBack.SetActive(true);
        yield return new WaitForSeconds(2f);
        mapBack.SetActive(false);
        alkashAnimator.gameObject.SetActive(false);
        mapFront.SetActive(true);
        yield return new WaitForSeconds(10f);
        mapFront.SetActive(false);
        alkashAnimator.gameObject.SetActive(true);
        mapBack.SetActive(true);
        yield return new WaitForSeconds(1f);
        mapBack.SetActive(false);
        yield return new WaitForSeconds(2f);
        alkashAnimator.gameObject.SetActive(false);
        street.SetActive(true);
        yield return new WaitForSeconds(3f);
        
        blackBg.gameObject.SetActive(true);
        time = 0f;
        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);
            blackBg.color = new Color(0, 0, 0, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex + 1);
    }
}