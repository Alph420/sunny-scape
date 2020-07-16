using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //--HP--//
    public int currentHealth;
    public const int maxHp = 100;
    public const int minHp = 0;

    //---COMPONENTS---//
    public HealthBar healthBar;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    //----VARIABLES----//
    public bool isInvincible = false;
    public float invisibilityFlashDelay;
    public int invisibilityDelay;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHp;
        healthBar.SetMaxHealth(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == minHp) Finish();
    }

    public void TakeDamage(int damage)
    {
        //Animation hurt 
        // animator.SetBool("TakeDamage", true);
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            Debug.Log("Vie actuel :" + currentHealth);
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invisibilityFlashDelay);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invisibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        while (isInvincible)
        {
            yield return new WaitForSeconds(invisibilityDelay);
            isInvincible = false;
        }
    }

    void Finish()
    {
        Destroy(gameObject);
    }
}
