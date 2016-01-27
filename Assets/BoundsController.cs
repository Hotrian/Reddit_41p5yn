using UnityEngine;

/// <summary>
/// Follows the player object so that if they fall outside of the level bounds they will hit us
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class BoundsController : MonoBehaviour
{
    public PlayerController playerController;

    void Update()
    {
        if (playerController != null)
        {
            gameObject.transform.position = new Vector3(playerController.gameObject.transform.position.x, -15f);
        }
        else
        {
            Debug.LogWarning("PlayerController missing");
            gameObject.SetActive(false);
        }
    }
}
