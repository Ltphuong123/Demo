using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab; // Prefab của quái vật
    [SerializeField] float spawnInterval = 2f; // Khoảng thời gian giữa mỗi lần spawn
    [SerializeField] Transform[] spawnPoints; // Mảng các vị trí spawn

    private float lastSpawnTime; // Thời điểm cuối cùng spawn

    void Start()
    {
        lastSpawnTime = Time.time; // Gán thời gian spawn cuối cùng khi bắt đầu
    }

    void Update()
    {
        // Kiểm tra nếu đã đến lúc spawn quái vật tiếp theo
        if (Time.time - lastSpawnTime >= spawnInterval)
        {
            SpawnEnemy(); // Spawn quái vật
            lastSpawnTime = Time.time; // Cập nhật thời điểm spawn cuối cùng
        }
    }

    void SpawnEnemy()
    {
        // Chọn một vị trí spawn ngẫu nhiên từ mảng spawnPoints
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Tạo quái vật tại vị trí spawn đã chọn
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
