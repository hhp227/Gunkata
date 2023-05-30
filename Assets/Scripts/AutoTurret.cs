using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoTurret : MonoBehaviour
{
    public GameObject projectilePrefab; // 발사체 프리팹
    public Transform spawnPoint; // 발사 위치
    public float launchForce = 10f; // 발사 속도
    public float fireRate = 1f; // 발사 주기
    public float rotationSpeed = 5f; // 포탑 회전 속도

    private float fireTimer; // 발사 타이머

    void Start()
    {
        fireTimer = fireRate;
    }

    void Update()
    {
        // 발사 타이머 업데이트
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            fireTimer = fireRate;
            FireProjectile(); // 발사
        }

        // 포탑 회전
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void FireProjectile()
    {
        // 발사체 프리팹 인스턴스화
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

        // 발사체에 속도 적용
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = spawnPoint.right * launchForce;
        }

        else
        {
            Debug.LogWarning("발사체에 Rigidbody2D 컴포넌트가 없습니다.");
        }
    }
}
