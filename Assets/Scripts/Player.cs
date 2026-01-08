using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Heart;
    Animator HeartAnimator;
    [SerializeField] float speed = 5f, speedRotation = 30f, maxTurn = 20f;
    float zRotation;
    GameManager gm;

    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        HeartAnimator = Heart.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) MoveUp();
        else MoveDown();
    }

    private void MoveDown() 
    {
        HeartAnimator.SetBool("IsFly", false);
        if (gameObject.transform.position.y > gm.BottomLeft.y)
            gameObject.transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
        if (zRotation > -maxTurn)
        {
            zRotation -= speedRotation * Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, zRotation);
        }
    }

    private void MoveUp()
    {
        HeartAnimator.SetBool("IsFly", true);
        if (gameObject.transform.position.y < gm.TopRight.y)
            gameObject.transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
        if (zRotation < maxTurn) 
        {
            zRotation += speedRotation * Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, zRotation);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vodka"))
        {
            print("u lost");
            gm.StopGameplay();
        }
    }
}
