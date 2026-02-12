using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    
    void Start()
    {
        print("Holla paposinto!");
    }
    
    void Update()
    {
        
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
}
