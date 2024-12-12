using UnityEngine;

public class SimpleSaver : MonoBehaviour
{
    // Start is called before the first frame update
    void Charger()
    {
        PlayerPrefs.GetInt("BananeAmount", 1);
        PlayerPrefs.GetInt("PearsAmount", 1);
        PlayerPrefs.GetString("PlayerName", "John");
    }

    void Sauvgarder()
    {
        PlayerPrefs.SetInt("BananeAmount", 1);
        PlayerPrefs.SetInt("PearsAmount", 1);
        PlayerPrefs.SetString("PlayerName", "John");
    }
}
