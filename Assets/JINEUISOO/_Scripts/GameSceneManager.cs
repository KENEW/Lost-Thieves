using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    private static GameSceneManager _sceneManager;
    public static GameSceneManager GSM
    {
        get
        {
            if(_sceneManager == null)
            {
                var tempSingleton = GameObject.FindObjectsOfType<GameSceneManager>();
                if (tempSingleton.Length == 1)
                {
                    _sceneManager = tempSingleton[0];
                }
                else if (tempSingleton.Length >= 2)
                {
                    _sceneManager = tempSingleton[0];
                    for(int ia = 1; ia < tempSingleton.Length; ia++)
                    {
                        Destroy(tempSingleton[ia]);
                    }
                }
            }

            return _sceneManager;
        }
    }

    [SerializeField] bool _testLoad, _testUnload;

    [SerializeField] bool _gameStartInitialization;
    [SerializeField] bool _isAllScenesLoaded;

    [SerializeField] List<AsyncOperation> _scenesLoaded = new List<AsyncOperation>();


    public ObjectType _playerSelectObjectType;
    public ObjectType _answerObjectType;

    public void SetPlayerSelectObjectType(ObjectType type) => _playerSelectObjectType = type;
    public ObjectType GetPlayerSelectObjectType() => _playerSelectObjectType;

    public void SetAnswerObjectType(ObjectType type) => _answerObjectType = type;
    public ObjectType GetAnswerObjectType() => _answerObjectType;

    private void Awake()
    {
        var thisSingleton = FindObjectsOfType<GameSceneManager>();
        if(thisSingleton.Length != 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(_gameStartInitialization)
        {
            _gameStartInitialization = false;
            RealGameStartInitialization();
        }
    }

    private void FixedUpdate()
    {
        if (_isAllScenesLoaded == false)
        {
            CheckSceneLoaded();
        }

        if(_testLoad)
        {
            _testLoad = false;
            LoadSceneAsync("SceneThree");
        }

        if(_testUnload)
        {
            _testUnload = false;
            UnLoadSceneAsync("SceneThree");
        }
    }

    void RealGameStartInitialization()
    {

    }

    void ChangeToFalseSceneLoadBool()
    {
        _isAllScenesLoaded = false;
    }

    bool CheckSceneLoaded()
    {
        foreach (AsyncOperation operation in _scenesLoaded)
        {
            Debug.Log($"SceneLoading Screen Turn On");
            Debug.Log($"Scene {operation.ToString()} {operation.progress} Complite.");
            if (operation.isDone == false)
                return false;
        }
        _isAllScenesLoaded = true;
        return true;
    }


    internal void LoadSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        ChangeToFalseSceneLoadBool();
        StartCoroutine(WaitUntilScenesLoadedAndSetActiveScene(sceneName));
    }

    internal void UnLoadSceneAsync(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
        ChangeToFalseSceneLoadBool();
    }

    internal void SetCenterOfScenes(string sceneName)
    {
        Scene[] scenes = new Scene[SceneManager.sceneCount];
        for (int ia = 0; ia < SceneManager.sceneCount; ia++)
        {
            scenes[ia] = SceneManager.GetSceneAt(ia);
        }

        for (int ia = 0; ia < scenes.Length; ia++)
        {
            if (scenes[ia].name == sceneName)
            {
                SceneManager.SetActiveScene(scenes[ia]);
                return;
            }
        }

        Debug.LogError("Check SceneName. Set active scene is failed.");
        return;
    }

    IEnumerator WaitUntilScenesLoadedAndSetActiveScene(string sceneName)
    {

        while (_isAllScenesLoaded == false)
        {
            Debug.Log($"Now waiting for All scenes loaded");
            yield return new WaitForSeconds(0.25f);
        }

        if (_isAllScenesLoaded == true)
        {
            SetCenterOfScenes(sceneName);
        }
    }
}
