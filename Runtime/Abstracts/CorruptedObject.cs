using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Corrupted
{
    public abstract class CorruptedObject : ServiceModel
    {

        public BindingFlags serializedFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;


        private Dictionary<FieldInfo, object> fields = new Dictionary<FieldInfo, object>();


        [SerializeField]
        bool isInitialized = false;

        public override void OnInitialize()
        {
            if (isInitialized)
                return;

            CloneInitialValues();
            Start();

            isInitialized = true;
        }

        public override void StopService()
        {

            if (isInitialized == false)
                return;

            OnDestroy();
            ResetValues();
            isInitialized = false;
        }

        void CloneInitialValues()
        {
            fields.Clear();
            var fieldInfos = GetType().GetFields(serializedFlags);
            foreach(var fi in fieldInfos)
            {
                fields.Add(fi, fi.GetValue(this));
                Debug.Log($"Clone value {fi.Name} of {fi.GetValue(this)}");
            }
        }

        void ResetValues()
        {
            foreach(var f in fields)
            {
                f.Key.SetValue(this, f.Value);
                Debug.Log($"Set value {f.Key.Name} to {f.Value}");
            }
        }


        protected abstract void Start();

        protected abstract void OnDestroy();

    }
}
