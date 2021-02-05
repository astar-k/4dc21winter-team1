﻿using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Enemy.SoftMochi {
    [RequireComponent(typeof(Collider2D))]
    public class SoftMochiHitBox : MonoBehaviour {
        [SerializeField] private int power = default;
        
        private void Start() {
            // 接触したオブジェクトが特定のインターフェイスを実装していたらダメージを与える
            this.OnTriggerEnter2DAsObservable()
                .Select(x => x.gameObject.GetComponent<IReceivableStab>())
                .Where(x => x != null)
                .Subscribe(x => x.ReceiveDamage(power))
                .AddTo(this);
        }
    }
}
