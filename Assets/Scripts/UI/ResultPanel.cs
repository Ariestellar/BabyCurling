using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _button;
    [SerializeField] private Sprite _imageDefeat;
    [SerializeField] private Sprite _buttonImageDefeat;
    [SerializeField] private Sprite _imageVictory;
    [SerializeField] private Sprite _buttonimageVictory;
    //[SerializeField] private Text _resultText;

    public void Show(StateGame stateGame)
    {
        if (SceneManager.sceneCountInBuildSettings > DataGame.currentLevel)
        {
            if (stateGame == StateGame.Victory)
            {
                _image.sprite = _imageVictory;
                _button.sprite = _buttonimageVictory;
                //_resultText.text = "Victory";
            }
            else if (stateGame == StateGame.Defeat)
            {
                _image.sprite = _imageDefeat;
                _button.sprite = _buttonImageDefeat;
                //_resultText.text = "Defeat";
            }
        }
        else
        {
            //_resultText.text = "End demo :(";
        }
    }
}
