using UnityEngine;
using UnityEngine.UI;
public class Points : MonoBehaviour
{
    public Text pointsText;
    private int points = 0;
    private float timer = 0.0f;
    private float interval = 1.0f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            points++;
            Debug.Log($"{points}");
            if (pointsText != null)
            {
                pointsText.text = $"{points}";
            }
            timer = 0.0f;
        }
    }
}