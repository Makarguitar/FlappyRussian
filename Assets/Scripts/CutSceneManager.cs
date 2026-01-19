using TMPro;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    public TextMeshProUGUI cutSceneText;

    public string[] dialogueLines =
    {
        "a",
        "b",
        "c",
    };
    
    void Start()
    {
        cutSceneText.text = dialogueLines[0];
    }

    void Update()
    {
        
    }
}
