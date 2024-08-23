using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;  // Referência ao transform do jogador
    [SerializeField] private Vector3 offset;    // Offset da câmera em relação ao jogador

    private void LateUpdate()
    {
        // Atualiza a posição da câmera para seguir o jogador com o offset
        transform.position = player.position + offset;
    }
}