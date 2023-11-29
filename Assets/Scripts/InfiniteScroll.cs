/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 * Edited by yangchang-n, 2023
 */

using System.Linq;
using UnityEngine;

class InfiniteScroll : MonoBehaviour
{
    [SerializeField] ScrollView scrollView = default;

    void Start()
    {
        var items = Enumerable.Range(1, 100)
            .Select(i => new ItemData($"Cell {i}"))
            .ToArray();

        scrollView.UpdateData(items);
        scrollView.SelectCell(0);
    }
}