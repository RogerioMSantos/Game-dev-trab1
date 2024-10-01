using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType; // Tipo da chave
    [SerializeField] private Sprite keySprite; // Sprite da chave

    public enum KeyType
    {
        Ruby1,
        Ruby2,
        Ruby3,
        Gold1,
        Gold2,
        Gem,
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }

    public Sprite GetSprite()
    {
        return keySprite;
    }
}
