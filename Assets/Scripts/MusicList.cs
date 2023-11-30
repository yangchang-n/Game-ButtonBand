/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 * Edited by yangchang-n, 2023
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

class MusicList : MonoBehaviour
{
    [SerializeField] ScrollView scrollView = default;

    void Start() // Task : ItemData를 담을 items를 IList로 선언하면서 크기도 바로 지정할 수 있게 바꾸기
    {
        // DirectoryInfo assetsDirectory = new DirectoryInfo(Application.persistentDataPath);
        DirectoryInfo assetsDirectory = new DirectoryInfo(Application.dataPath);
        DirectoryInfo resourcesDirectory = new DirectoryInfo(assetsDirectory + "/Resources");
        DirectoryInfo musicDirectory = new DirectoryInfo(resourcesDirectory + "/Music");

        int countMusic = 0;
        foreach (DirectoryInfo musicTitle in musicDirectory.GetDirectories())
        {
            countMusic ++;
        }

        var items = Enumerable.Range(0, countMusic)
            .Select(i => new ItemData($"Cell {i}"))
            .ToArray();

        int temp = 0; // 임시방편으로 구현 (비효율적)
        foreach (DirectoryInfo musicTitle in musicDirectory.GetDirectories())
        {
            string stringTitle = musicTitle.Name.ToString();
            items[temp] = new ItemData(stringTitle);
            temp ++;
        }

        scrollView.UpdateData(items);
        scrollView.SelectCell(0);
    }
}