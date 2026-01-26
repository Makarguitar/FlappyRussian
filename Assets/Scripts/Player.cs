using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Heart, Heart2, Heart3;
    Animator HeartAnimator, HeartAnimator2, HeartAnimator3;
    [SerializeField] float speed = 5f, speedRotation = 30f, maxTurn = 20f;
    float zRotation;
    GameManager gm;
    [SerializeField] private int lives = 3;

    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        HeartAnimator = Heart.GetComponent<Animator>();
        HeartAnimator2 = Heart2.GetComponent<Animator>();
        HeartAnimator3= Heart3.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) MoveUp();
        else MoveDown();

        if (lives <= 0)
        {
            Destroy(Heart);
            gm.StopGameplay();
        }

        if (lives == 2)
        {
            Destroy(Heart3);
        }

        if (lives == 1)
        {
            Destroy(Heart2);
        }
    }

    private void MoveDown() 
    {
        if (lives >= 1)
            HeartAnimator.SetBool("IsFly", false);
        if (lives >= 2)
            HeartAnimator2.SetBool("IsFly", false);
        if (lives >= 3)
            HeartAnimator3.SetBool("IsFly", false);
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
        if (lives >= 1)
            HeartAnimator.SetBool("IsFly", true);
        if (lives >= 2)
            HeartAnimator2.SetBool("IsFly", true);
        if (lives >= 3)
            HeartAnimator3.SetBool("IsFly", true);
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
            lives--;
        }
    }
}
