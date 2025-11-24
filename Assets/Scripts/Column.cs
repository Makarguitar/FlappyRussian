using UnityEngine;

public class Column : MonoBehaviour
{
    [SerializeField] Transform columnTop, columnBottom;
    [SerializeField] float minOffset, maxOffset;

    void Start()
    {
        float offset = Random.Range(minOffset, maxOffset) / 2;
        columnTop.position += new Vector3(0, offset, 0);
        columnBottom.position -= new Vector3(0, offset, 0);
    }

    void Update()
    {
        
    }
}
