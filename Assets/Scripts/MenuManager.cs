using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;
    [SerializeField] private GameObject _keyboardRebindingCanvasGO;
    [SerializeField] private GameObject _gamepadRebindingCanvasGO;

    [Header("Player Scripts to Deactivate on pause")]
    // [SerializeField] private Player _player;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _settingsMenuFirst;
    [SerializeField] private GameObject _keyboardRebindingMenuFirst;
    [SerializeField] private GameObject _gamepadRebindingMenuFirst;


    private bool isPaused;

    private void Start()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
    }

    private void Update()
    {
        // if (InputHandler.instance.MenuOpenCloseInput)
        // {
        //     InputHandler.instance.UseMenuOpenCloseInput();

        //     if (!isPaused)
        //     {
        //         Pause();
        //     }
        //     else
        //     {
        //         Unpause();
        //     }
        // }
    }

    #region Pause / UnPause Methods
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        // _player.enabled = false;

        OpenMainMenu();
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        CloseAllMenus();
    }
    #endregion

    #region Canvas Activations/Deactivations
    private void OpenMainMenu()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    private void OpenSettingsMenuHandle()
    {
        _settingsMenuCanvasGO.SetActive(true);
        _mainMenuCanvasGO.SetActive(false);
        _keyboardRebindingCanvasGO.SetActive(false);
        _gamepadRebindingCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }

    private void CloseAllMenus()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }

    private void OpenKeyboardRebindingMenu()
    {
        _settingsMenuCanvasGO.SetActive(false);
        _keyboardRebindingCanvasGO.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_keyboardRebindingMenuFirst);
    }

    private void OpenGamepadRebindingMenu()
    {
        _settingsMenuCanvasGO.SetActive(false);
        _gamepadRebindingCanvasGO.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_gamepadRebindingMenuFirst);
    }
    #endregion

    #region Button Pressed Methods
    public void OnSettingPressed()
    {
        OpenSettingsMenuHandle();
    }

    public void OnResumePressed()
    {
        Unpause();
    }

    public void OnSettingsBackPressed()
    {
        OpenMainMenu();
    }

    public void OnKeyboardRebindingPressed()
    {
        OpenKeyboardRebindingMenu();
    }

    public void OnGamepadRebindingPressed()
    {
        OpenGamepadRebindingMenu();
    }
    #endregion
}