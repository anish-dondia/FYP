﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAudioOn : MonoBehaviour
{
    private static KeepAudioOn audioPlayer;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (audioPlayer == null)
        {
            audioPlayer = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
