using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f; // For�a do pulo
    public LayerMask groundLayer; // Camada que representa o ch�o
    public float groundCheckDistance = 0.1f; // Dist�ncia de verifica��o do ch�o

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verifica se o jogador est� no ch�o
        bool isGrounded = IsGrounded();

        // Pula quando a tecla de espa�o � pressionada e o jogador est� no ch�o
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            JumpAction();
        }
    }

    bool IsGrounded()
    {
        // Raycast para baixo para verificar se o jogador est� no ch�o
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    void JumpAction()
    {
        // Adiciona uma for�a para fazer o jogador pular
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Reseta a velocidade vertical para evitar pulos duplos
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
