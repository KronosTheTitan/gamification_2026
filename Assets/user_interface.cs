using System;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class user_interface : MonoBehaviour
{
    [SerializeField] private UIDocument ui_document;

    private Button notification_button;
    private Button badge_menu_open_button;
    private Button badge_menu_close_button;
    private Button gallery_open_button;
    private Button gallery_close_button;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ui_document == null)
            ui_document = gameObject.GetComponent<UIDocument>();
        
        //setup buttons
        
        notification_button = ui_document.rootVisualElement.Q<Button>("notification");
        badge_menu_open_button = ui_document.rootVisualElement.Q<Button>("badge_button_active");
        badge_menu_close_button = ui_document.rootVisualElement.Q<Button>("back_button");

        gallery_open_button = ui_document.rootVisualElement.Q<Button>("gallery_open_button");
        gallery_close_button = ui_document.rootVisualElement.Q<Button>("gallery_close_button");

        notification_button.clicked += on_notification_clicked;
        badge_menu_open_button.clicked += on_badge_menu_open_button_clicked;
        badge_menu_close_button.clicked += on_badge_menu_close_button_clicked;

        gallery_open_button.clicked += on_gallery_open_button_clicked;
        gallery_close_button.clicked += on_gallery_close_button_clicked;

        ScrollView art_list = ui_document.rootVisualElement.Q<ScrollView>("artwork_list");
        art_list.ScrollTo(ui_document.rootVisualElement.Q<Button>("badge_button_active"));

        ScrollView map = ui_document.rootVisualElement.Q<ScrollView>("badges_container");
        map.ScrollTo(ui_document.rootVisualElement.Q<Button>("gallery_open_button"));
    }

    private void on_gallery_open_button_clicked()
    {
        VisualElement gallery = ui_document.rootVisualElement.Q<VisualElement>("gallery_of_honor_menu");
        VisualElement container = ui_document.rootVisualElement.Q<VisualElement>("badges_main_container");

        container.style.display = DisplayStyle.None;
        gallery.style.display = DisplayStyle.Flex;
    }

    private void on_gallery_close_button_clicked()
    {
        VisualElement gallery = ui_document.rootVisualElement.Q<VisualElement>("gallery_of_honor_menu");
        VisualElement container = ui_document.rootVisualElement.Q<VisualElement>("badges_main_container");

        container.style.display = DisplayStyle.Flex;
        gallery.style.display = DisplayStyle.None;
    }

    private void on_notification_clicked()
    {
        notification_button.visible = false;
    }

    private void on_badge_menu_open_button_clicked()
    {
        VisualElement gallery = ui_document.rootVisualElement.Q<VisualElement>("gallery_of_honor_menu");
        VisualElement badge_menu = ui_document.rootVisualElement.Q<VisualElement>("honorable_dogs_badge");

        gallery.style.display = DisplayStyle.None;
        badge_menu.style.display = DisplayStyle.Flex;
    }

    private void on_badge_menu_close_button_clicked()
    {
        VisualElement gallery = ui_document.rootVisualElement.Q<VisualElement>("gallery_of_honor_menu");
        VisualElement badge_menu = ui_document.rootVisualElement.Q<VisualElement>("honorable_dogs_badge");

        gallery.style.display = DisplayStyle.Flex;
        badge_menu.style.display = DisplayStyle.None;
    }
}
