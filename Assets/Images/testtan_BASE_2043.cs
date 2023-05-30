using UnityEngine;

public class testtan : MonoBehaviour
{
    public float speed = 10f;
    public GameObject hitEffectPrefab;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}