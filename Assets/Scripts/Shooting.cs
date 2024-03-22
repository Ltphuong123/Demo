using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab; // Prefab của viên đạn
    [SerializeField] Transform firePoint; // Vị trí bắn đạn
    [SerializeField] float bulletSpeed = 10f; // Tốc độ của viên đạn
    [SerializeField] float bulletLifetime = 1f; // Thời gian tồn tại của viên đạn

    void Update()
    {
        // Kiểm tra xem người chơi có click chuột không
        if (Input.GetButtonDown("Fire1")) // Kiểm tra nút chuột trái
        {
            Shoot(); // Bắn đạn
        }
    }

    void Shoot()
    {
        // Tạo một đối tượng viên đạn từ prefab tại vị trí bắn và hướng lên trước
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Lấy component Rigidbody2D của viên đạn để điều khiển vận tốc
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set vận tốc của viên đạn
        rb.velocity = firePoint.up * bulletSpeed;

        // Xóa viên đạn sau một khoảng thời gian
        Destroy(bullet, bulletLifetime);
    }
}
