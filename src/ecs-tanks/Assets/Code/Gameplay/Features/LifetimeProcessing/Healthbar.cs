using Fusion;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Code.Gameplay.Features.LifetimeProcessing
{
    public class Healthbar : NetworkBehaviour
    {
        [SerializeField] private Slider _hpSlider;
        [Networked] private float _value { get; set; }

        internal void UpdateValue(float currentHP, float maxHP)
        {
            _value = currentHP / maxHP;
        }

        public override void Render()
        {
            _hpSlider.value = _value;
        }
    }
}