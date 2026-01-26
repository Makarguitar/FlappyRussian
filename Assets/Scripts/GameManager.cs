using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector2 BottomLeft { get; private set; }
    public Vector2 TopRight { get; private set; }
    [SerializeField] private TextMeshProUGUI timerText;
    private float time;
    [SerializeField] private GameObject coloumnsPrefab;
    [SerializeField] private float coloumnSpawnTime;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI timeAvoidingVodka;

    void Start()
    {
        Time.timeScale = 1f;
        BottomLeft = LocalVectorToWorld(0, 0);
        TopRight = LocalVectorToWorld(1, 1);
        InvokeRepeating(nameof(SpawnColoumns), 0, coloumnSpawnTime);
    }

    void Update()
    {
        time += Time.deltaTime;
        timerText.text = $"Time : {(int)time}";
    }

    private Vector3 LocalVectorToWorld(float x, float y)
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(x, y));
    }

    void SpawnColoumns()
    {
        GameObject coloumns = Instantiate(coloumnsPrefab);
        coloumns.transform.position = new Vector3(TopRight.x, 0, 0);
    }
    
    public void StopGameplay()
    {
        timeAvoidingVodka.text = $"Your Time Avoiding Vodka : {(int)time}";
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
