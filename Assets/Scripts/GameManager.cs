using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 BottomLeft { get; private set; }
    public Vector2 TopRight { get; private set; }
    [SerializeField] private TextMeshProUGUI timerText;
    private float time;
    [SerializeField] private GameObject coloumnsPrefab;
    [SerializeField] private float coloumnSpawnTime;

    void Start()
    {
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
}
