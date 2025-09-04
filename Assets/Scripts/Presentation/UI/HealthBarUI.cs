using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    // Esta variable nos permitirá arrastrar el objeto del Jugador
    // (que tiene el script PlayerHealth) desde la jerarquía de la escena
    // hasta el campo correspondiente en el Inspector.
    [SerializeField] private PlayerHealth playerHealth;

    private void OnEnable()
    {
        // Aquí es donde ocurre la "magia".
        // Usamos el operador '+=' para añadir nuestro método 'UpdateHealthDisplay'
        // a la lista de "oyentes" del evento OnHealthChanged.
        playerHealth.OnHealthChanged += UpdateHealthDisplay;
    }

    private void OnDisable()
    {
        // Es CRUCIAL desuscribirse para evitar errores.
        // Si no lo hacemos y el objeto de la UI se destruye,
        // PlayerHealth intentaría llamar a un método en un objeto que ya no existe.
        playerHealth.OnHealthChanged -= UpdateHealthDisplay;
    }

    private void UpdateHealthDisplay() 
    {
        // Por ahora, solo mostraremos un mensaje en la consola.
        // En el futuro, aquí es donde actualizaríamos una barra de vida real (un Slider, una Imagen, etc.).

        // Podemos acceder a la vida actual del jugador a través de su propiedad pública.
        // Fíjate cómo solo podemos LEER el valor, no escribirlo. ¡Encapsulación en acción!
        int currentHealth = playerHealth.CurrentHealth;
        Debug.Log($"UI NOTIFIED: Player health changed. New Value: {currentHealth}");
    }


}
