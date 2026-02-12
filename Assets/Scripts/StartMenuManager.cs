using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public GameObject controlsPanel;
    public bool controlPanelOn = false;
    
    void Start()
    {
        print("Holla paposinto!");
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (controlPanelOn)
            {
                controlsPanel.SetActive(false);
                controlPanelOn = false;
            }
        }
    }

    public void NextLevel()
    {
        print("holla");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void Quit()
    {
        print("mamosinto");
        Application.Quit();
    }

    public void ShowControls()
    {
        controlsPanel.SetActive(true);
        controlPanelOn = true;
    }
}
