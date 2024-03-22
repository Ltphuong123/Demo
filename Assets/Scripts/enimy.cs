using UnityEngine;

public class enimy : MonoBehaviour
{
    [SerializeField] float speed = 2f; // Tốc độ di chuyển
    [SerializeField] float speedRda = 2f;
    [SerializeField] float amplitude = 1f; // Biên độ của đồ thị sin
    [SerializeField] float frequency = 3f; // Tần số của đồ thị sin
    float dy;
    float delta = 0;


    void Start()
    {
        dy = transform.position.y;

    }
    void Update()
    {
        Move();
    }

    void Move()
    {

        delta += speedRda * Time.deltaTime;
        if (delta >= 2 * Mathf.PI) delta = 0;

        float x = transform.position.x + speed * Time.deltaTime;
        if (x >= 3.5 || x <= -3.5) speed *= -1;

        float y = dy + Mathf.Sin(delta * frequency) * amplitude;

        transform.position = new Vector3(x, y, 0f);
    }
}