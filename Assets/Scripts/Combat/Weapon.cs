using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] GameObject equippedPrefab = null;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float weaponRange = 2f;
        [SerializeField] bool isRightHanded = true;

        public void Spawn(Transform rightHand, Transform leftHand, Animator anim)
        {
            if (equippedPrefab != null)
            {
                Transform handTransform;
                if (isRightHanded)
                {
                    handTransform = rightHand;
                }
                else
                {
                    handTransform = leftHand;
                }
                Instantiate(equippedPrefab, handTransform);
            }
            if (animatorOverride != null)
            {
                anim.runtimeAnimatorController = animatorOverride;
            }
        }

        public float GetWeaponDamage()
        {
            return weaponDamage;
        }
        public float GetWeaponRange()
        {
            return weaponRange;
        }
    }
}
