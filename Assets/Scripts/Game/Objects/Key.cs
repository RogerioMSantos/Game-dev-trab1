using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
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
}
