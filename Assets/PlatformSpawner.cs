using UnityEngine;

/// <summary>
/// Spawns platforms and walls as the player moves along the level.
/// Instantiate should be replaced with an ObjectPool if this were to be used in a real game.
/// </summary>
public class PlatformSpawner : MonoBehaviour
{
    public GameObject PlatformPrefab;

    private float lastSpawnX = -80f;
    void Update()
    {
        while (lastSpawnX < gameObject.transform.position.x)
        {
            if (PlatformPrefab != null)
            {
                if (Random.Range(0f, 1f) > 0.2f) // Spawn platform
                {
                    float tScale = Random.Range(4f, 8f); // Size of the platform
                    lastSpawnX += tScale + Random.Range(2f, 4f); // + distance between objects
                    GameObject tGo = (GameObject)Instantiate(PlatformPrefab, new Vector3(lastSpawnX + 40f, Random.Range(-5f, 5f)), Quaternion.identity);
                    tGo.transform.localScale = new Vector3(tScale, 1f, 1f);
                }
                else // Spawn wall
                {
                    float tScale = Random.Range(2f, 4f); // Size of the wall
                    lastSpawnX += Random.Range(3f, 5f); // Distance between objects
                    GameObject tGo = (GameObject)Instantiate(PlatformPrefab, new Vector3(lastSpawnX + 40f, Random.Range(-5f, 5f)), Quaternion.identity);
                    tGo.transform.localScale = new Vector3(1f, tScale, 1f);
                }
            }
            else
            {
                Debug.LogWarning("PlatformPrefab missing");
                lastSpawnX += 10f; // Move forward anyway so we don't loop forever
            }
        }
    }
}
