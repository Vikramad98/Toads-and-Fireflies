using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    [SerializeField]
    private Toad toad;
    [SerializeField]
    private Game game;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Firefly"))
        {
            game.addPoints(toad.Player, collision.GetComponent<Firefly>().pointValue);
            Destroy(collision.gameObject);
        }
    }
}
