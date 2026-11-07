using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private UnityEvent<float> onHealthChanged;
    [SerializeField] private UnityEvent onDeath;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        onHealthChanged.Invoke((float)currentHealth / maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        onHealthChanged.Invoke((float)currentHealth / maxHealth);
        
        if (currentHealth == 0)
        {
            onDeath.Invoke();
        }
    }
}
