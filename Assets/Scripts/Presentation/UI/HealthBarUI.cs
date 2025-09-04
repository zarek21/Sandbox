using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    // Esta variable nos permitir� arrastrar el objeto del Jugador
    // (que tiene el script PlayerHealth) desde la jerarqu�a de la escena
    // hasta el campo correspondiente en el Inspector.
    [SerializeField] private PlayerHealth playerHealth;

    private void OnEnable()
    {
        // Aqu� es donde ocurre la "magia".
        // Usamos el operador '+=' para a�adir nuestro m�todo 'UpdateHealthDisplay'
        // a la lista de "oyentes" del evento OnHealthChanged.
        playerHealth.OnHealthChanged += UpdateHealthDisplay;
    }

    private void OnDisable()
    {
        // Es CRUCIAL desuscribirse para evitar errores.
        // Si no lo hacemos y el objeto de la UI se destruye,
        // PlayerHealth intentar�a llamar a un m�todo en un objeto que ya no existe.
        playerHealth.OnHealthChanged -= UpdateHealthDisplay;
    }

    private void UpdateHealthDisplay() 
    {
        // Por ahora, solo mostraremos un mensaje en la consola.
        // En el futuro, aqu� es donde actualizar�amos una barra de vida real (un Slider, una Imagen, etc.).

        // Podemos acceder a la vida actual del jugador a trav�s de su propiedad p�blica.
        // F�jate c�mo solo podemos LEER el valor, no escribirlo. �Encapsulaci�n en acci�n!
        int currentHealth = playerHealth.CurrentHealth;
        Debug.Log($"UI NOTIFIED: Player health changed. New Value: {currentHealth}");
    }


}
