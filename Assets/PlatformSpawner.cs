using UnityEngine;

/// <summary>
/// Spawns platforms as the player moves along the level
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
                float tScale = Random.Range(4f, 8f); // Size of the platform
                lastSpawnX += tScale + Random.Range(2f, 4f); // + distance between platform
                GameObject tGo = (GameObject) Instantiate(PlatformPrefab, new Vector3(lastSpawnX + 40f, Random.Range(-5f, 5f)), Quaternion.identity);
                tGo.transform.localScale = new Vector3(tScale, 1f, 1f);
            }
            else
            {
                Debug.LogWarning("PlatformPrefab missing");
                lastSpawnX += 10f;
            }
        }
    }
}
