using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    [SerializeField] private TMP_Text messageText; 
    private void OnCollisionEnter2D(Collision2D collision)
    {

        KeyHolder keyHolder = collision.gameObject.GetComponent<KeyHolder>();
        if (keyHolder != null && keyHolder.ContainsKey(keyType))
        {
            OpenDoor();
            keyHolder.RemoveKey(keyType);
        }
        else if (keyType.Equals(Key.KeyType.Gem) && !keyHolder.ContainsKey(keyType))
        {
            messageText.text = "Preciso achar a joia primeiro!";
            StartCoroutine(ClearMessage());

        }
    }

    private void OpenDoor()
    {

        Destroy(gameObject);

    }

    private IEnumerator ClearMessage()
    {
        yield return new WaitForSeconds(2); // Espera 2 segundos.
        messageText.text = ""; // Limpa a mensagem.
    }
}
