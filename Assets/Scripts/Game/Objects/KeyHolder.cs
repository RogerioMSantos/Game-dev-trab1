using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;

    [SerializeField] private Image keyImage;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType, Sprite keySprite)
    {
        keyList.Add(keyType);
        UpdateKeyImage(keySprite);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        if (keyList.Count == 0)
        {
            keyImage.sprite = null;
            Color color = keyImage.color;
            color.a = 0;
            keyImage.color = color;
        }
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Key key = collision.GetComponent<Key>();

        if (key != null)
        {
            AddKey(key.GetKeyType(), key.GetSprite());
            Destroy(key.gameObject);
        }
    }

    private void UpdateKeyImage(Sprite keySprite)
    {
        keyImage.sprite = keySprite;
        Color color = keyImage.color;
        color.a = 1f;
        keyImage.color = color;
    }
}
