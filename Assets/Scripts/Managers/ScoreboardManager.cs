using System;
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
        
        var scoreEntries = CurrentStateData.GetScoreEntries();
        for (var i = 1; i <= scoreEntries.Count; i++)
        {
            var entry = Instantiate(scoreEntryPrefab, content.transform);
            var entryRectTransform = entry.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -40 - 50 * i);
            
            var entryTextFields = entry.GetComponentsInChildren<TMP_Text>();
            entryTextFields[0].text = "# " + i;
            entryTextFields[1].text = scoreEntries[i-1].playerName;

            int secs, mins;
            secs = Mathf.FloorToInt(scoreEntries[i-1].playTime);
            (mins, secs) = (secs / 60, secs % 60);
            entryTextFields[2].text = $"{mins}m {secs}s";
        }

        // Fit content size
        var contentRectTransform = content.GetComponent<RectTransform>();
        var contentSizeDelta = contentRectTransform.sizeDelta;
        contentRectTransform.sizeDelta = new Vector2(contentSizeDelta.x, 50 * Math.Max(8, scoreEntries.Count) + contentSizeDelta.y);

        var scrollRect = GetComponent<ScrollRect>();
        scrollRect.verticalNormalizedPosition = 1f;
    }
}