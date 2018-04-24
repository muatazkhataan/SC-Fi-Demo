using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip _coinPicUp;

    // Check for collision (onTrigger)
    private void OnTriggerStay(Collider other)
    {
        // Check if player
        if (other.tag == "Player")
        {
            // Chek for E press
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    // Give player the coin
                    player.hasCoin = true;

                    // Play coin Sound
                    AudioSource.PlayClipAtPoint(clip: _coinPicUp, position: transform.position, volume: 1f);


                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                    if (uiManager != null)
                    {
                        uiManager.CollectedCoin();
                    }

                    // Destroy the Coin
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
