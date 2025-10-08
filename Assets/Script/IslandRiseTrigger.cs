using UnityEngine;

public class IslandRiseTrigger : MonoBehaviour
{
    public MushroomCollector mushroomCollector;
    public Transform island;
    public float riseHeight = 16f; // -20 to -4
    public float riseSpeed = 2f;
    private bool hasRisen = false;
    public AudioSource riseAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasRisen && mushroomCollector.mushroomCount >= 3)
        {
            StartCoroutine(RaiseIsland());
            hasRisen = true;
        }
    }

    private System.Collections.IEnumerator RaiseIsland()
    {
        Vector3 startPosition = island.position;
        Vector3 endPosition = startPosition + Vector3.up * riseHeight;

        if (riseAudio != null)
        {
            riseAudio.Play();
        }

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * riseSpeed;
            island.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        if (riseAudio != null)
        {
            riseAudio.loop = false;
            riseAudio.Stop();
        }

        Debug.Log("Island has risen");
    }
}
