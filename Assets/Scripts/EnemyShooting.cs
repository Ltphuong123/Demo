using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab của viên đạn
    public Transform firePoint; // Vị trí bắn đạn
    public float bulletSpeed = 10f; // Tốc độ của viên đạn
    public float shootingInterval = 1f; // Khoảng thời gian giữa mỗi lần bắn
    public float bulletLifetime = 1f; // Thời gian tồn tại của viên đạn

    private float lastShootTime; // Thời điểm cuối cùng bắn đạn

    void Start()
    {
        lastShootTime = Time.time; // Gán thời gian bắn cuối cùng khi bắt đầu
    }

    void Update()
    {
        // Kiểm tra nếu đã đến lúc bắn tiếp theo
        if (Time.time - lastShootTime >= shootingInterval)
        {
            Shoot(); // Bắn đạn
            lastShootTime = Time.time; // Cập nhật thời điểm cuối cùng bắn
        }
    }

    void Shoot()
    {
        // Tạo một đối tượng viên đạn từ prefab tại vị trí bắn và hướng xuống
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f, 0f, -90f));

        // Lấy component Rigidbody2D của viên đạn để điều khiển vận tốc
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set vận tốc của viên đạn
        rb.velocity = -firePoint.up * bulletSpeed;

        // Xóa viên đạn sau một khoảng thời gian
        Destroy(bullet, bulletLifetime);
    }
}
