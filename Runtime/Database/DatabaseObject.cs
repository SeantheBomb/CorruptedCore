using PlasticGui.Configuration.CloudEdition.Welcome;
using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Corrupted
{

    [CreateAssetMenu(fileName = "Database", menuName = "Corrupted/Database")]
    public class DatabaseObject : ScriptableObject
    {

        public Database storedDatabase;

        public DatabasePage[] GetPages()
        {
            return storedDatabase.GetPages();
        }

        public DatabasePage GetPage(string id)
        {
            return storedDatabase.GetPage(id);
        }
      
    }


    [System.Serializable]
    public class Database
    {
        //private Dictionary<string, DatabasePage> pages;
        private List<DatabasePage> pages;

        public Database()
        {
            pages = new List<DatabasePage>();
        } 

        public void AddPage<T>(string id, T value)
        {
            DatabasePage<T> page = new DatabasePage<T>(id, value);
            pages.Add( page);
        }

        public T GetValue<T>(string id)
        {
            return pages.Where((p) => p.ID.Equals(id)).FirstOrDefault().GetValue<T>();
            //if(pages.TryGetValue(id, out DatabasePage page))
            //{
            //    return page.GetValue<T>();
            //}
            //else
            //{
            //    Debug.LogError($"Database: Failed to retrieve page because id {id} is invalid");
            //    return default;
            //}
        }

        public DatabasePage GetPage(string id)
        {
            var page = pages.Where((p) => p.ID.Equals(id)).FirstOrDefault();

            Debug.Log($"Database: Get page {id} {(page != null ? page.Title : "Null")}");
            return page;
            //if (pages.TryGetValue(id, out DatabasePage page))
            //{
            //    return page;
            //}
            //else
            //{
            //    Debug.LogError($"Database: Failed to retrieve page because id {id} is invalid");
            //    return null;
            //}
        }

        public DatabasePage[] GetPages()
        {
            return pages.ToArray();
        }
    }


    [System.Serializable]
    public abstract class DatabasePage
    {

        protected bool _isDirty = false;

        public abstract string ID { get; }

        public abstract string Title { get; }

        public abstract Type Type { get; }

        public abstract object ObjectValue { get; }

        public abstract void SetValue(object value);

        public abstract T GetValue<T>();

        public void SetDirty()
        {
            _isDirty = true;
        }

    }

    [System.Serializable]
    public class DatabasePage<T> : DatabasePage
    {

        protected T _value;

        public override object ObjectValue => GetValue();

        public override Type Type => typeof(T);

        public override string ID => _id;

        public override string Title => _title;

        [SerializeField]
        protected string _id, _title;

        public DatabasePage(string id, T value)
        {
            _id = id;
            //_title = title;
            _value = value;
        }


        public virtual T GetValue()
        {
            return _value;
        }

        public override K GetValue<K>()
        {
            if (GetValue() is K k)
                return k;
            else
            {
                Debug.LogError($"Database: Failed to get value from page {Title} because it is the wrong type {typeof(K)} instead of {typeof(T)}");
                return default;
            }
        }

        public override void SetValue(object value)
        {
            if(value is T t)
                _value = t;
            else
                Debug.LogError($"Database: Failed to set value for {ID} ({value}) because it is the wrong type");
        }

    }
}
