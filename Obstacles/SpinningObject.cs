using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    [SerializeField] public float rotateX = 0f;
    [SerializeField] public float rotateY = 1f;
    [SerializeField] public float rotateZ = 0f;
    
    void Update()
    {
        transform.Rotate(rotateX, rotateY, rotateZ);
    }
}
