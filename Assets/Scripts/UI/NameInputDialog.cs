using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInputDialog : MonoBehaviour
{
    [SerializeField] private InputField _inputField;
    [SerializeField] private Button _buttonOk;

    private TouchHandler _touchHandler;

    public void Init(TouchHandler touchHandler)
    {
        _touchHandler = touchHandler;
    }

    public void SetName()//Запускаем время игры
    {
        if (_inputField.text != string.Empty)
        {
            DataGame.SetNamePlayer(_inputField.text);
            this.gameObject.SetActive(false);
            _touchHandler.gameObject.SetActive(true);
        }        
    }
}
