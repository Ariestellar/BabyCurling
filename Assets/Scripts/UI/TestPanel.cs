using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestPanel : MonoBehaviour
{
    [SerializeField] private Dropdown _listLevel;

    public void ChangedLevel()
    {        
        DataGame.currentLevel = _listLevel.value;
        SceneTransition.SwitchToScene("Level" + DataGame.currentLevel);
        //SceneManager.LoadScene("Level" + DataGame.currentLevel);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        DataGame.currentLevel = 1;
        SceneManager.LoadScene(0);
    }
}
