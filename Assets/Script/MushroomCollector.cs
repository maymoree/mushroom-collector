using UnityEngine;
using TMPro;

public class MushroomCollector : MonoBehaviour
{
    public TextMeshProUGUI mushroomCountText;
    public int mushroomCount = 0;
    public AudioSource collectSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateInventoryText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mushroom"))
        {
            Destroy(other.gameObject); // remove mushroom from scene
            mushroomCount++;
            UpdateInventoryText();

            if (collectSound != null)
            {
                collectSound.Play();
            }

        }
    }

    void UpdateInventoryText()
    {
        if (mushroomCount < 3)
        {
            mushroomCountText.text = "Purple Mushrooms: " + mushroomCount.ToString() + "/3";
            Debug.Log("Mushroom collected: " + mushroomCount);
        }
        else
        {
            mushroomCountText.text = "All mushrooms collected!";
        }
    }

}
