using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Spawner))]
public class GameSessionCurrentLevel: MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private UIPanel _uiPanel;

    private TouchHandler _touchHandler;       
    private StateGame _stateGame;    
    private CanvasScaler _canvasScaler;    
    private int _numberProjectilePulling;
    private int _numberProjectileAtTarget;
    private CameraMovement _mainCameraMovement;
    private Spawner _spawner;
    private List<GameObject> _currentProjectile;    

    public StateGame StateLevel => _stateGame;
    public int NumberProjectilePulling => _numberProjectilePulling;
    public TouchHandler TouchHandler => _touchHandler;

    private void Awake()
    {        
        _canvasScaler = _uiPanel.GetComponent<CanvasScaler>();
        _mainCameraMovement = _mainCamera.GetComponent<CameraMovement>();
        _spawner = GetComponent<Spawner>();
        _touchHandler = _uiPanel.GetTouchHandler();        
    }

    private void Start()
    {
        _uiPanel.SetTextLevel(DataGame.currentLevel);
        _touchHandler.startLevel += StartCurrentLevel;
        if (Screen.width <= 480)
        {
            _canvasScaler.scaleFactor = 1;
        } 
        else if (Screen.width <= 750)
        {
            _canvasScaler.scaleFactor = 2;
        }
        else if (Screen.width <= 1080)
        {
            _canvasScaler.scaleFactor = 3;
        }

        _touchHandler.gameObject.SetActive(true);
        _spawner.CreateProjectile(this);
        if (DataGame.isMainMenu == false)
        {
            StartCurrentLevel();
        }                        
    }

    public void ResetLevel()
    {
        ResetData(DataGame.currentLevel);
        _spawner.DeleteCurrentProjectline();        
        _touchHandler.gameObject.SetActive(true);
        _spawner.CreateProjectile(this);
    }

    public void ContinueLevel()
    {
        if (StateLevel == StateGame.Victory)
        {            
            DataGame.LevelUp();
            SceneTransition.SwitchToScene("Level" + DataGame.currentLevel);
            //SceneManager.LoadScene("Level" + DataGame.currentLevel);            
        }
        else
        {
            ResetLevel();
        }
    }

    public void IncreaseNumberProjectilePulling()
    {
        _numberProjectilePulling += 1;        
    }

    public void IncreaseNumberProjectileAtTarget()
    {
        _numberProjectileAtTarget += 1;              
    }

    public void ReduceNumberProjectileAtTarget()
    {
        _numberProjectileAtTarget -= 1;        
    }

    public CameraMovement GetCameraMovement()
    {
        return _mainCameraMovement;
    }

    public Camera GetMainCamera()
    {
        return _mainCamera;
    }

    public AudioManager GetAudioManager()
    {
        return _audioManager;
    }

    private void Defeat()
    {
        _touchHandler.gameObject.SetActive(false);
        _stateGame = StateGame.Defeat;
        _uiPanel.ShowResultPanel(_stateGame);        
    }

    private void Victory()
    {
        _touchHandler.gameObject.SetActive(false);
        _stateGame = StateGame.Victory;
        _uiPanel.ShowResultPanel(_stateGame);        
    }

    public void  CheckVictory()
    {
        if (_numberProjectileAtTarget >= 2)
        {           
            Victory();
        }
        else if(_numberProjectilePulling == 4)
        {            
            Defeat();
        }
        else
        {
            _mainCameraMovement.ReturnPosition();
            _mainCameraMovement.DeleteTarget();
            _spawner.CreateProjectile(this);            
        }
    }
    public void CheckHittingZone()
    {
        _currentProjectile = _spawner.CurrentProjectile;        

        for (int i = 0; i < _currentProjectile.Count; i++)
        {
            if (_currentProjectile[i].GetComponent<CheckHitting>().HittingZone == true)
            {
                _uiPanel.SetColorLifePanel(i, Color.green);
            }
            else
            {
                _uiPanel.SetColorLifePanel(i, Color.grey);
            }
        }        
    }

    public void ResetData(int currentLevel)
    {        
        _mainCameraMovement.ReturnPosition();               
        _numberProjectilePulling = 0;
        _numberProjectileAtTarget = 0;
        _uiPanel.ResetLifePanel();            
        _uiPanel.HideResultPanel();
    }

    private void StartCurrentLevel()
    {
        _uiPanel.ShowBrifing();
        _uiPanel.ShowLifePanel();
        _uiPanel.HideButtonMainMenu();
        _mainCameraMovement.ReturnPosition();               
    }
}
