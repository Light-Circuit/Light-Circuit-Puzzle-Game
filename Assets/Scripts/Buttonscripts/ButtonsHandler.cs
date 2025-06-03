using UnityEngine;
using UnityEngine.UI;

public class ButtonsHandler : MonoBehaviour
{
    [SerializeField] Button[] levelButtons;
    [SerializeField] Sprite kilit;           
    [SerializeField] Sprite acik;             

    string numberOfLevelsUnlocked = "numberOfLevelsUnlocked";
    int unlockedLevels;
    int oldUnlockedLevels;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(numberOfLevelsUnlocked))
        {
            PlayerPrefs.SetInt(numberOfLevelsUnlocked, 1);
        }

        unlockedLevels = PlayerPrefs.GetInt(numberOfLevelsUnlocked);
        oldUnlockedLevels = unlockedLevels;

        ApplyUnlockStatus();
    }

    private void Update()
    {
        unlockedLevels = PlayerPrefs.GetInt(numberOfLevelsUnlocked);
        if (oldUnlockedLevels != unlockedLevels)
        {
            ApplyUnlockStatus();
            oldUnlockedLevels = unlockedLevels;
        }
    }

    private void ApplyUnlockStatus()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            LevelButton lb = levelButtons[i].GetComponent<LevelButton>();
            if (lb != null)
            {
                bool isLevelUnlocked = (i < unlockedLevels);
                lb.isUnlocked = isLevelUnlocked;

               
                levelButtons[i].image.sprite = isLevelUnlocked ? acik : kilit;
                levelButtons[i].transform.GetChild(0).gameObject.SetActive(isLevelUnlocked);

               
                Text text = levelButtons[i].GetComponentInChildren<Text>();
                if (text != null)
                {
                    text.color = isLevelUnlocked ? Color.white : Color.gray;
                }
            }
        }
    }
}
