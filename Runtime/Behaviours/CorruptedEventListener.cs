using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Corrupted {

    public class CorruptedEventListener : CorruptedBehaviour
    {

        public CorruptedEvent Event;

        public bool nextFrame = true;
        public bool subscribeIfDisabled = false;
        public UnityEvent Response;

        public float delay;

        bool subscribed = false;

        
        private void OnEnable()
        {
            if (subscribed)
                return;
            Event.RegisterListener(this);
            subscribed = true;     
        }

        private void OnDisable()
        {
            Event.UnRegisterListener(this);
            subscribed = false;
        }

        private void OnApplicationQuit()
        {
            if (subscribed)
                OnDisable();
        }

        public void OnEventRaised()
        {
            if (this == null)
            {
                Debug.LogError("CorruptedEvent: Event fired with missing reference!!");
                return;
            }
            if (nextFrame && enabled && gameObject.activeInHierarchy)
                StartCoroutine(OnEventRaisedCR());
            else
            Response?.Invoke();
        }

        IEnumerator OnEventRaisedCR()
        {
            yield return null;
            if (delay > 0) yield return new WaitForSeconds(delay);
            Response?.Invoke();
        }

        public void RaiseEvent()
        {
            Event?.Raise();
        }

        
        static void SubscribeIfDisabled()
        {
            Debug.Log("CorruptedEvent: Subscribed from attribute!");
            foreach (CorruptedEventListener instance in FindObjectsOfType<CorruptedEventListener>(true))
            {
                if (instance.subscribeIfDisabled == false)
                    continue;
                if (instance.gameObject.activeInHierarchy == false || instance.enabled == false)
                {
                    instance.OnEnable();
                    Debug.Log($"CorruptedEvent: {instance.name} subscribed to event {instance.Event.name}");
                }
            }
        }

        [RuntimeInitializeOnLoadMethod]
        static void SubscribeToSceneLoad()
        {
            SceneManager.sceneLoaded += (Scene s, LoadSceneMode lsm) => SubscribeIfDisabled();
            SubscribeIfDisabled();
        }

    }
}