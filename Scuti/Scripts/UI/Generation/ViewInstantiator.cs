﻿using Scuti.UI;
using System;
using UnityEngine;
using NaughtyAttributes;

namespace Scuti {
    [Serializable]
    public class ViewInstantiator {
        public string id = "New View Instantiator";
        public View view;
        public View view_portrait;
        public Transform parent;

        [ReadOnly] [SerializeField] View instance;

        void Start() { }

        void OnValidate() {
            if (id.Contains("/"))
                id.Replace("/", "");
        }

        public View Instantiate() {


            bool portrait = ScutiUtils.IsPortrait();
            var v = portrait && view_portrait != null ? view_portrait : view;
            instance = MonoBehaviour.Instantiate(v, parent);
            instance.gameObject.hideFlags = HideFlags.DontSave;
            return instance;
        }

        internal void Destroy() {
            MonoBehaviour.Destroy(instance.gameObject);
        }
    }
}