using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f; // Força do pulo
    public LayerMask groundLayer; // Camada que representa o chão
    public float groundCheckDistance = 0.1f; // Distância de verificação do chão

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verifica se o jogador está no chão
        bool isGrounded = IsGrounded();

        // Pula quando a tecla de espaço é pressionada e o jogador está no chão
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            JumpAction();
        }
    }

    bool IsGrounded()
    {
        // Raycast para baixo para verificar se o jogador está no chão
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    void JumpAction()
    {
        // Adiciona uma força para fazer o jogador pular
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Reseta a velocidade vertical para evitar pulos duplos
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
