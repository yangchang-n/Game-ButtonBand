/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 * Edited by yangchang-n, 2023
 */

using UnityEngine;
using UnityEngine.UI;
using FancyScrollView;

class Cell : FancyCell<ItemData, Context>
{
    [SerializeField] Animator animator = default;
    [SerializeField] Text message = default;
    [SerializeField] Image image = default;
    [SerializeField] Button button = default;

    static class AnimatorHash
    {
        public static readonly int Scroll = Animator.StringToHash("scroll");
    }

    void Start()
    {
        button.onClick.AddListener(() => Context.OnCellClicked?.Invoke(Index));
    }

    public override void UpdateContent(ItemData itemData)
    {
        message.text = itemData.Message;

        var selected = Context.SelectedIndex == Index;
        image.color = selected
            ? new Color32(255, 255, 255, 255)
            : new Color32(255, 255, 255, 100);
    }

    public override void UpdatePosition(float position)
    {
        currentPosition = position;

        if (animator.isActiveAndEnabled)
        {
            animator.Play(AnimatorHash.Scroll, -1, position);
        }

        animator.speed = 0;
    }

    float currentPosition = 0;

    void OnEnable() => UpdatePosition(currentPosition);
}