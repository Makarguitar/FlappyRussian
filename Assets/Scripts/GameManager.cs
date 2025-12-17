using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 BottomLeft { get; private set; }
    public Vector2 TopRight { get; private set; }
    [SerializeField] private TextMeshProUGUI timerText;
    private float time;

    void Start()
    {
        BottomLeft = LocalVectorToWorld(0, 0);
        TopRight = LocalVectorToWorld(1, 1);
    }

    void Update()
    {
        time += Time.deltaTime;
        timerText.text = $"Time : {time}";
    }

    private Vector3 LocalVectorToWorld(float x, float y)
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(x, y));
    }
}
