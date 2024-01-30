using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
}
