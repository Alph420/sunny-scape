using UnityEngine;

public class WeakSpot : MonoBehaviour{

    public EnnemyPatrol ennemyPatrol;
    public GameObject objectToDestroy;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int layer = 0;
            ennemyPatrol.speed = layer;
            animator.SetBool("Death", true);
            Destroy(objectToDestroy,0.25f);
        }
    }
}
