using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth = 100;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack = 50;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense = 30;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed = 20;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;

            CurrentHealth = baseHealth;
        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth { get; private set; }
        public TYPE BaseType { get => _baseType; set => _baseType = TYPE.NORMAL; }
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                int _maxHealth = _baseHealth;
                if(CurrentEquipment != null)
                {
                    _maxHealth += CurrentEquipment.BonusHealth;
                }
                return _maxHealth;
            }
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                int _attack = _baseAttack;
                if(CurrentEquipment != null) 
                {
                    _attack += CurrentEquipment.BonusAttack;
                }
                return _attack;
            }
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                int _defense = _baseDefense;
                if( CurrentEquipment != null)
                {
                    _defense += CurrentEquipment.BonusDefense;
                }
                return _defense;
            }
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                int _speed = _baseSpeed;
                if( CurrentEquipment != null)
                {
                    _speed += CurrentEquipment.BonusSpeed;
                }
                return _speed;
            }
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get; private set; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        public bool IsAlive => CurrentHealth > 0 ;


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            if (s != null)
            {
                CurrentHealth -= s.Power - Defense;
                CurrentStatus = null;
                if(CurrentHealth <= 0)
                {
                    CurrentHealth = 0;
                }
            }
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if(newEquipment == null)
            {
                throw new ArgumentNullException();
            }
            CurrentEquipment = newEquipment;
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            if(CurrentEquipment != null)
            {
                CurrentEquipment = null;
            }
        }

    }
}
