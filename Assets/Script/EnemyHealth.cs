using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    private int currentHealth;
    private void Start()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        DetectHealth();
    }
    private void DetectHealth()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
