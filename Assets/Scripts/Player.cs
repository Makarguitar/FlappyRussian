using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f, speedRotation = 30f;
    float zRotation;
    GameManager gm;

    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) MoveUp();
        else MoveDown();
    }

    private void MoveDown() 
    {
        if (gameObject.transform.position.y > gm.BottomLeft.y)
            gameObject.transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
    }

    private void MoveUp()
    {
        if (gameObject.transform.position.y < gm.TopRight.y)
            gameObject.transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
        zRotation += speedRotation * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }
}
