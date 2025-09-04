using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Variables for player health
    [SerializeField]private int maxHealth = 100;

    // Estado Y propiedades
    // Propiedad p�blica para leer, pero privada para modificar.
    // Cualquiera puede preguntar "�cu�l es tu vida?", pero solo PlayerHealth puede cambiarla.
    public int CurrentHealth { get; private set; }

    // --- El Evento ---
    // La pieza clave para la comunicaci�n desacoplada.
    // Notificar� a los suscriptores cuando la vida cambie.
    public event Action OnHealthChanged;

    private void Awake()
    {
        // Inicializamos la vida al m�ximo al empezar
        CurrentHealth = maxHealth;
    }

    //  --- L�gica de Gameplay ---
    // El m�todo ahora tiene UNA sola responsabilidad: aplicar da�o
    public void TakeDamage(int damageAmount) 
    {
        if (damageAmount < 0) return;

        // Reducimos la vida actual
        CurrentHealth -= damageAmount;

        // Nos aseguramos de que la vida no baje de 0 y no pase de 100
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
        //Current Healt = Valor que se va fijar  0 = min value, maxHealth = max Value


        // �Notificamos al mundo que algo ha cambiado!
        // El '?' es un chequeo de nulidad. Solo invoca si hay suscriptores.
        OnHealthChanged?.Invoke();

        Debug.Log($"Player took {damageAmount} damage. Current health: {CurrentHealth}");

        if (CurrentHealth <= 0) 
        {
            Die();
        }
    }

    private void Die() 
    {
        Debug.Log("Player has died");
    }


} // End Of class
