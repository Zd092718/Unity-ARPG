using UnityEngine;
using TMPro;
using RPG.Attributes;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI enemyHealthText;
        Fighter fighter;
        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }
        private void Update()
        {
            if (fighter.GetTarget() == null)
            {
                enemyHealthText.text = "N/A";
                return;
            }
            Health health = fighter.GetTarget();
            enemyHealthText.text = string.Format("{0}%", Mathf.RoundToInt(health.GetPercentage()));
        }
    }

}