﻿using Library.Pause;
using UnityEngine;

namespace Enemy.Boss {
    /// <summary>
    /// Bossの情報をまとめるクラス
    /// </summary>
    public class BossMediator : MonoBehaviour, IPausable {
        private Behaviour behaviour;
        
        private void Start() {
            Pauser.AddList(this);
            behaviour = GetComponent<Behaviour>();
        }

        public void Pause() {
            behaviour.enabled = false;
        }

        public void Resume() {
            behaviour.enabled = true;
        }

        public void OnDisable() {
            Pauser.RemoveList(this);
        }
    }
}
