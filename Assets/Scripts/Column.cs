using UnityEngine;

public class Column : MonoBehaviour
{
    [SerializeField] Transform columnTop, columnBottom;
    [SerializeField] float minOffset, maxOffset;
    [SerializeField] float speed = 5f;
    GameManager gm;
    
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        float offset = Random.Range(minOffset, maxOffset) / 2;
        columnTop.position += new Vector3(0, offset, 0);
        columnBottom.position -= new Vector3(0, offset, 0);
    }

    void Update()
    {
        if (gameObject.transform.position.x > gm.BottomLeft.x - gameObject.transform.localScale.x / 2)
        {
            gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
