using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPAndDeath : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool useRigidbody2D = true;
    [SerializeField] private bool destroyWhenBelow = true;
    [SerializeField] private float destroyBelowY = 1f;
    public GameManager gameManager;

    // Update is called once per frame
    private void Update()
    {
        if (destroyWhenBelow && transform.position.y < destroyBelowY)
        {
            gameManager.GameOver();
        }
    }
}
