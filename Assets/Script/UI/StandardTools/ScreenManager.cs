using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenManager : VisualElement
{
    VisualElement _gameScreen;
    VisualElement _questionScreen;
    VisualElement _bottomNavigationBar;

    public new class UxmlFactory : UxmlFactory<ScreenManager, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits { }

    public ScreenManager()
    {
        this.RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }

    void OnGeometryChange(GeometryChangedEvent evt)
    {
        _gameScreen = this.Q("GameScreen");
        _questionScreen = this.Q("QuestionScreen");
        _bottomNavigationBar = this.Q("BottomNavigationBar");

        _bottomNavigationBar.Q("Button1").RegisterCallback<ClickEvent>(ev => EnableScreen1());
        _bottomNavigationBar.Q("Button2").RegisterCallback<ClickEvent>(ev => EnableScreen2());

        this.UnregisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }

    void EnableScreen1()
    {
        _gameScreen.style.display = DisplayStyle.Flex;
        _questionScreen.style.display = DisplayStyle.None;
    }

    void EnableScreen2()
    {
        _gameScreen.style.display = DisplayStyle.None;
        _questionScreen.style.display = DisplayStyle.Flex;
    }
}
