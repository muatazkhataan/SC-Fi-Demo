using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {
    // Check fo a collision
    private void OnTriggerStay(Collider other)
    {
        // Check if player
        if (other.tag == "Player")
        {
            // Check for E key
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                // Remove coin from player
                if (player.hasCoin == true)
                {
                    player.hasCoin = false;
                    // Update the inventory display
                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                    if (uiManager != null)
                    {
                        uiManager.RemoveCoin();
                    }

                    // Play win sound
                    AudioSource audio = GetComponent<AudioSource>();
                    audio.Play();
                }
                // Debug Get out of here! You do not have coin
                else
                {
                    Debug.Log("Get out of here! You do not have coin.");
                }
            }
        }
    }
}
