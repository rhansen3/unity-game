using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private Button _resumeButton;
    private Button _quitButton;
    public UIMenuManager uiMenuManager;

    //Add logic that interacts with the UI controls in the `OnEnable` methods
    private void OnEnable()
    {
        // The UXML is already instantiated by the UIDocument component
        var uiDocument = GetComponent<UIDocument>();

        _resumeButton = uiDocument.rootVisualElement.Q("resumeButton") as Button;
        _quitButton = uiDocument.rootVisualElement.Q("quitButton") as Button;

        _resumeButton.RegisterCallback<ClickEvent>(resumeGame);
        _resumeButton.RegisterCallback<ClickEvent>(quitGame);
    }

    private void resumeGame(ClickEvent evt)
    {
        uiMenuManager.unpauseGame();
        uiMenuManager.pauseMenuOpen = false;
        gameObject.SetActive(false);
    }

    private void quitGame(ClickEvent evt){
        Application.Quit();
    }

}
