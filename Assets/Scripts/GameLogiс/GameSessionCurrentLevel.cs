using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Spawner))]
public class GameSessionCurrentLevel: MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private SecondCameraMovement _secondCameraMovement;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private UIPanel _uiPanel;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private GameObject _firework;
    [SerializeField] private TypesPlayingField _typesPlayingField;

    private TouchHandler _touchHandler;       
    private StateGame _stateGame;    
    private CanvasScaler _canvasScaler;    
    private int _numberProjectilePulling;    
    private CameraMovement _mainCameraMovement;
    private Spawner _spawner;    
    private int _totalScore;

    public StateGame StateLevel => _stateGame;    
    public TouchHandler TouchHandler => _touchHandler;
    public Transform TargetPosition => _targetPosition;

    private void Awake()
    {        
        _canvasScaler = _uiPanel.GetComponent<CanvasScaler>();
        _mainCameraMovement = _mainCamera.GetComponent<CameraMovement>();
        _spawner = GetComponent<Spawner>();
        _touchHandler = _uiPanel.GetTouchHandler();        
    }

    private void Start()
    {
        _uiPanel.SetTextLevel(SceneManager.GetActiveScene().buildIndex);
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
    public CameraMovement GetCameraMovement()
    {
        return _mainCameraMovement;
    }

    public SecondCameraMovement GetSecondCameraMovement()
    {
        return _secondCameraMovement;
    }

    public Camera GetMainCamera()
    {
        return _mainCamera;
    }

    public AudioManager GetAudioManager()
    {
        return _audioManager;
    }
    public void IncreaseNumberProjectilePulling()
    {
        _numberProjectilePulling += 1;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }

    //После остановки запущенного снаряда проверям остановились ли все другие снаряды
    public void CheckHittingZone()
    {
        /*_totalScore = GetTotalScore(_spawner.CurrentProjectile);
        _uiPanel.SetCountScore(_totalScore);
        CheckVictory();*/
        StartCoroutine(WaitingAllProjectileStop(_spawner.CurrentProjectile));
    }   

    public void ContinueLevel()
    {
        if (StateLevel == StateGame.Victory)
        {
            DataGame.LevelUp();
            SceneManager.LoadScene("Level" + DataGame.currentLevel);
        }
        else
        {
            ResetLevel();
        }
    }

    private void StartCurrentLevel()
    {
        _uiPanel.ShowBrifing();
        _uiPanel.ShowLifePanel();
        _uiPanel.HideButtonMainMenu();
        _mainCameraMovement.ReturnPosition();
    }

    private void Defeat()
    {
        _touchHandler.gameObject.SetActive(false);
        _stateGame = StateGame.Defeat;
        _uiPanel.ShowResultPanel(_stateGame);        
    }

    private void Victory()
    {
        List<GameObject>  currentProjectile = _spawner.CurrentProjectile;
        _firework.SetActive(true);
        for (int i = 0; i < currentProjectile.Count; i++)
        {
            if (i % 2 == 0)
            {
                currentProjectile[i].GetComponent<Projectile>().AnimationStateDancing(TypesDances.BreakDancing);
            }
            else
            {
                currentProjectile[i].GetComponent<Projectile>().AnimationStateDancing(TypesDances.SambaDancing);
            }
            
        }
        StartCoroutine(ShowResultVictoryPanel());        
    }

    //Проверяем все ли снаряды на сцене остановились(т.к. могут быть те кто продолжает катиться от толчка)
    private bool СheckingStopAllProjectiles(List<GameObject> currentProjectile)
    {
        bool numberProjectileInFlight = false;
        foreach (var projectile in currentProjectile)
        {
            if (projectile.GetComponent<ProjectileFlight>().IsFlight == true)
            {
                numberProjectileInFlight = true;
            }
        }
        return numberProjectileInFlight;
    }

    //Ожидаем пока все снаряды прекратять катится потом запускаем подсчет очков и проверку условий победы
    private IEnumerator WaitingAllProjectileStop(List<GameObject> currentProjectile)
    {
        yield return new WaitForFixedUpdate();
        if (СheckingStopAllProjectiles(currentProjectile) == false)
        {
            Debug.Log("Все прекратили катиться");
            _totalScore = GetTotalScore(currentProjectile);
            _uiPanel.SetCountScore(_totalScore);
            CheckVictory();
            yield break;
        }
    }

    private IEnumerator ShowResultVictoryPanel()
    {
        yield return new WaitForSeconds(3);
        _touchHandler.gameObject.SetActive(false);
        _stateGame = StateGame.Victory;
        _uiPanel.ShowResultPanel(_stateGame);
    }

    private void  CheckVictory()
    {        
        if (_numberProjectilePulling == 4)
        {
            if (_totalScore > 100)
            {
                Victory();
            }
            else
            {
                Defeat();
            }            
        }
        else
        {
            _mainCameraMovement.ReturnPosition();
            _mainCameraMovement.DeleteTarget();
            _spawner.CreateProjectile(this);            
        }
    }

    private int GetTotalScore(List<GameObject> currentProjectile)
    {        
        int totalScore = 0;
        foreach (var projectile in currentProjectile)
        {
            totalScore += projectile.GetComponent<CheckHitting>().GetCountScore(_typesPlayingField);
        }        
        return totalScore;
    }
}
