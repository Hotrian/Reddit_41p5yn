using UnityEngine;

/// <summary>
/// Follows the player object so that if they fall outside of the level bounds they will hit us
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class BoundsController : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (player != null)
        {
            gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, -15f);
        }
        else
        {
            Debug.LogWarning("Trackable GameObject missing");
            gameObject.SetActive(false);
        }
    }
}
