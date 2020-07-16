using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnnemyPatrol : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Animator animator;


    public float speed;
    public Transform[] wayPoints;

    private Transform target;
    private int destPoint;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        target = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        //Si l'ennemie est quasiment  arriver a sa destination alors
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % wayPoints.Length;
            target = wayPoints[destPoint];
            sprite.flipX = !sprite.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
    }
}
