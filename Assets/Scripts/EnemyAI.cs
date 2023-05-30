using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public float bulletSpeed = 5f;
    public Transform gunBarrel;
    public GameObject bulletPrefab;
    //public Animator animator;

    private bool isPlayerDetected = false;

    private void Start()
    {
        FindPlayer();
        InvokeRepeating("Attack", 1f, 1f); // 1�ʸ��� Attack �Լ��� ȣ��
    }

    private void FindPlayer()
    {
        //GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        //if (playerObject != null)
        //{
        //    player = playerObject.transform;
        //}
        //else
        //{
        //    Debug.LogError("Player object not found!");
        //}
    }

    private void Update()
    {
        if (!isPlayerDetected)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer < detectionRange){
                isPlayerDetected = true;
                //animator.SetBool("isWalking", true);
            }else{
                MoveEnemy();
            }
        }else{
            ChasePlayer();
        }
    }

    private void MoveEnemy(){
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void ChasePlayer()
    {
        //�÷��̾� ��/�� ��ġ Ȯ��
        Vector2 direction = player.position - transform.position;
        //AI �÷��̾�� ����
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);

        //AI �¿� ����
        if (direction.x > 0){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if (direction.x < 0) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, Quaternion.identity);

        Vector2 direction = player.position - gunBarrel.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction * bulletSpeed;

        //animator.SetTrigger("attack");
    }
}