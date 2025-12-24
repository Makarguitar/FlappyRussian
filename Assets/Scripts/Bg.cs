using UnityEngine;

public class Bg : MonoBehaviour
{
    [SerializeField] private float speed;
    private Material material;
    
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
