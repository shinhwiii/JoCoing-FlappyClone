using UnityEngine;

public class MakePipe : MonoBehaviour
{
    [SerializeField]
    private GameObject pipe;
    [SerializeField]
    private float timeDiff;

    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeDiff)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = new Vector3(6, Random.Range(-2f, 5f), 0);
            timer = 0;

            Destroy(newPipe, 10f);
        }
    }
}
