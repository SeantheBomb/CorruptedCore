using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    public abstract class CorruptedCommandListener<T> : MonoBehaviour
    {

        public System.Action<CorruptedCommand<T>> OnCommandStart, OnCommandEnd, WhileCommand;
        public System.Action<CorruptedAxisCommand<T>, float> OnCommandAxis;


        public CommandListener[] buttons;
        public CommandAxisListener[] axes;

        protected T receiver;

        public abstract T GetReceiver();

        protected virtual void Start()
        {
            receiver = GetReceiver();
            foreach (CommandListener l in buttons)
            {
                l.command.OnStart(receiver);
            }
            foreach (CommandAxisListener l in axes)
            {
                l.command.OnStart(receiver);
            }
            //Can you see this?
        }

        private void Update()
        {
            foreach (CommandListener l in buttons)
            {
                if (l.isValid == false)
                    continue;

                if (Input.GetKeyDown(l.input))
                {
                    l.command.StartExecute(receiver);
                    OnCommandStart?.Invoke(l.command);
                }
                if (Input.GetKey(l.input))
                {
                    l.command.WhileExecute(receiver);
                    WhileCommand?.Invoke(l.command);
                }
                if (Input.GetKeyUp(l.input))
                {
                    l.command.EndExecute(receiver);
                    OnCommandEnd?.Invoke(l.command);
                }
            }
            foreach (CommandAxisListener l in axes)
            {
                if (l.isValid == false)
                    continue;

                float axis = Input.GetAxis(l.axis);
                if (axis != 0 && l.lastFrameValue == 0)
                    l.command.StartExecute(receiver);
                else if (axis == 0 && l.lastFrameValue != 0)
                    l.command.EndExecute(receiver);

                l.command.WhileExecute(receiver, axis);
                OnCommandAxis?.Invoke(l.command, axis);
                l.lastFrameValue = axis;
            }
        }

        public CommandListener GetCommandListener(CorruptedCommand<T> command)
        {
            foreach (CommandListener cl in buttons)
            {
                if (cl.command == command)
                {
                    return cl;
                }
            }
            return null;
        }

        public CommandAxisListener GetAxisListener(CorruptedAxisCommand<T> command)
        {
            foreach (CommandAxisListener cl in axes)
            {
                if (cl.command == command)
                {
                    return cl;
                }
            }
            return null;
        }

        [System.Serializable]
        public class CommandListener
        {
            public string name;
            public KeyCode input;
            public CorruptedCommand<T> command;
            public bool isValid = true;
        }

        [System.Serializable]
        public class CommandAxisListener
        {
            public string name;
            public string axis;
            public CorruptedAxisCommand<T> command;
            [HideInInspector] public float lastFrameValue;
            public bool isValid = true;
        }
    }


}
