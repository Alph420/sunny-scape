using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text coinsCountText;
    public int coinsCount;

    public static Inventory instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("+ de 1 instance");
            return;
        }

        instance = this;

    }

    public void AddCoin(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();

    }
}
