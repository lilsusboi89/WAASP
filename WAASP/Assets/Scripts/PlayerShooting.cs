using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Shooting Settings")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootSpeed = 10f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);

        Vector2 shootDirection = GetShootDirection();
        if (shootDirection != Vector2.zero)
        {
            Shoot(shootDirection);
        }
    }

    Vector2 GetShootDirection()
    {
        float horizontalInput2 = Input.GetAxis("Horizontal2");
        float verticalInput2 = Input.GetAxis("Vertical2");

        return new Vector2(horizontalInput2, verticalInput2).normalized;
    }

    void Shoot(Vector2 shootDirection)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * shootSpeed;

        SpriteRenderer bulletRenderer = bullet.GetComponent<SpriteRenderer>();
        if (bulletRenderer != null)
        {

        }

        Destroy(bullet, 2f);
    }
}
