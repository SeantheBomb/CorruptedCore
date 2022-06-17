using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Corrupted
{
    [CreateAssetMenu(fileName = "FlagVariable", menuName = "Corrupted/Variable/Flag", order = 0)]
    public class FlagValue : BoolValue
    {

        public static System.Action<FlagValue> OnAnyFlagUpdated;
        public System.Action<bool> OnUpdated;

        [TextArea]
        public string description;


        public void Raise()
        {
            SetValue(true);
        }

        public void Lower()
        {
            SetValue(false);
        }

        public void Toggle()
        {
            SetValue(!Value);
        }


        /// <summary>
        /// Updates the flag's value and triggers the updated event
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(bool value)
        {
            Value = value;
            RaiseEvent();
        }

        void RaiseEvent()
        {
            OnUpdated?.Invoke(Value);
            OnAnyFlagUpdated?.Invoke(this);
        }
    }


}
