using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoTurret : MonoBehaviour
{
    public GameObject projectilePrefab; // �߻�ü ������
    public Transform spawnPoint; // �߻� ��ġ
    public float launchForce = 10f; // �߻� �ӵ�
    public float fireRate = 1f; // �߻� �ֱ�
    public float rotationSpeed = 5f; // ��ž ȸ�� �ӵ�

    private float fireTimer; // �߻� Ÿ�̸�

    void Start()
    {
        fireTimer = fireRate;
    }

    void Update()
    {
        // �߻� Ÿ�̸� ������Ʈ
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            fireTimer = fireRate;
            FireProjectile(); // �߻�
        }

        // ��ž ȸ��
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void FireProjectile()
    {
        // �߻�ü ������ �ν��Ͻ�ȭ
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

        // �߻�ü�� �ӵ� ����
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = spawnPoint.right * launchForce;
        }

        else
        {
            Debug.LogWarning("�߻�ü�� Rigidbody2D ������Ʈ�� �����ϴ�.");
        }
    }
}
