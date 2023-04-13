using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardManager : MonoBehaviour
{
    public GameObject scoreEntryPrefab;
    public GameObject content;

    private void Start()
    {
        // Header of scoreboard
        var header = Instantiate(scoreEntryPrefab, content.transform);
        var headerRectTransform = header.GetComponent<RectTransform>();
        headerRectTransform.anchoredPosition = new Vector2(0, -20);
        
        var headerTextFields = header.GetComponentsInChildren<TMP_Text>();
        headerTextFields[0].text = "Rank";
        headerTextFields[1].text = "Player Name";
        headerTextFields[2].text = "Time Spent";

        // @TODO change this to actual instantiations
        const int numberOfItems = 21;
        for (var i = 1; i <= numberOfItems; i++)
        {
            var entry = Instantiate(scoreEntryPrefab, content.transform);
            var entryRectTransform = entry.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -40 - 50 * i);
            
            var entryTextFields = entry.GetComponentsInChildren<TMP_Text>();
            entryTextFields[0].text = "# " + i;
            entryTextFields[1].text = "Player " + i;
            entryTextFields[2].text = "20m 45s";
        }

        // Fit content size
        var contentRectTransform = content.GetComponent<RectTransform>();
        var contentSizeDelta = contentRectTransform.sizeDelta;
        contentRectTransform.sizeDelta = new Vector2(contentSizeDelta.x, 50 * numberOfItems + contentSizeDelta.y);

        var scrollRect = GetComponent<ScrollRect>();
        scrollRect.verticalNormalizedPosition = 1f;
    }
}