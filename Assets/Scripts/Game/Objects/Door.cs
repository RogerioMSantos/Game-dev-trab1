using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        KeyHolder keyHolder = collision.gameObject.GetComponent<KeyHolder>();
        if (keyHolder != null && keyHolder.ContainsKey(keyType))
        {
            OpenDoor();
            keyHolder.RemoveKey(keyType); // Remove a chave do inventário do player
        }
    }

    private void OpenDoor()
    {

        Destroy(gameObject);

    }
}
