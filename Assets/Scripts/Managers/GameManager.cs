﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Managers
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;
        public float dayCycleDelay = 30f;
        public float nightCycleEndingDelay = 5f;
        public Text messageText;

        private int _roundNumber = 0;                 // Which round the game is currently on.
        private WaitForSeconds _nightCycleEndingWait;           // Used to have a delay whilst the round or game ends.

        private void Awake()
        {
            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

        }

        private void Start()
        {
            StartCoroutine(GameLoop());
        }

        void Update()
        {

        }

        private IEnumerator GameLoop()
        {
            yield return StartCoroutine(DayCycleStarting());

            yield return StartCoroutine(DayCyclePlaying());

            yield return StartCoroutine(DayCycleEnding());

            yield return StartCoroutine(NightCycleStarting());

            yield return StartCoroutine(NightCyclePlaying());

            yield return StartCoroutine(NightCycleEnding());

            StartCoroutine(GameLoop());
        }

        private IEnumerator DayCycleStarting()
        {
            //TODO: Enable traps placement, sheeps interactions, player control. Start day light.

            _roundNumber++;
            messageText.text = "ROUND " + _roundNumber;

            yield return null;
        }

        private IEnumerator DayCyclePlaying()
        {
            messageText.text = string.Empty;
            float localDayCycleDelay = Time.time + dayCycleDelay;
            
            while (!Input.GetKeyDown(KeyCode.K) ||  Time.time  < localDayCycleDelay)
            {
                yield return null;
            }
        }

        private IEnumerator DayCycleEnding()
        {
            //TODO: Disable traps placement, sheeps interactions. Start night light.

            yield return null;
        }

        private IEnumerator NightCycleStarting()
        {
            yield return null;
        }
        private IEnumerator NightCyclePlaying()
        {
            //TODO: while there are wolves alive or there is one sheep

            yield return null;
        }

        private IEnumerator NightCycleEnding()
        {
            //TODO: Disable player control

            //TODO: Round recap or game recap if game over.

            yield return null;
        }
    }
}