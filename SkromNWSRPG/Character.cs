using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SkromNWSRPG
{
    /*
     * Cette classe représente un Personnage dans le Jeu
     *
     * Elle possède un Name
     * Elle possède une valeur de Life
     *
     * Cette Classe possède une Méthode Equip
     * Elle prend en paramètre un équipement et l'applique au slot correspondant du Character
     *
     * Le Character peut porter une arme dans les deux mains, à condition que ce soit un Weapon
     * Un objet à deux mains bloque l'emplacement OffHand et Weapon
     *
     * équiper un objet à une main 2 fois de suite dans Weapon l'équipe dans Weapon & OffHand
     *
     *
     * Cette Classe possède une Methode GetItemInSlot
     * Elle prend en paramètre un GearSlot
     * Elle renvoie l'objet équipé à l'emplacement passé en paramètre
     * Elle renvoie null si il n'y a rien à cet emplacement
     */
    public class Character
    {
        public string Name;
        public int Life;
        public Dictionary<GearSlot, Gear> Stuff = new Dictionary<GearSlot, Gear>();
        public bool state = false;
        public Character(string name, int life)
        {
            Name = name;
            Life = life;
            InitStuff();
        }

        public void InitStuff()
        {
            Stuff[GearSlot.Head] = null;
            Stuff[GearSlot.Back] = null;
            Stuff[GearSlot.Chest] = null;
            Stuff[GearSlot.Legs] = null;
            Stuff[GearSlot.Feet] = null;
            Stuff[GearSlot.Weapon] = null;
            Stuff[GearSlot.TwoHand] = null;
            Stuff[GearSlot.OffHand] = null;
        }

        public void Equip(Gear gears)
        {
            if (gears.Slot == GearSlot.TwoHand)
            {
                Stuff[GearSlot.Weapon] = gears;
                Stuff[GearSlot.OffHand] = null;
            }
            if(gears.Slot == GearSlot.Weapon)
            {
                if (state == true)
                {
                    Stuff[GearSlot.OffHand] = gears;
                    state = false;
                }
                else
                {
                    Stuff[GearSlot.Weapon] = gears;
                    state = true;
                }
                Stuff[GearSlot.TwoHand] = null;
            }
            
            if (gears.Slot == GearSlot.OffHand)
            {
                Stuff[GearSlot.OffHand] = gears;
                Stuff[GearSlot.Weapon] = null;
            }
            if (gears.Slot == GearSlot.Back)
            {
                Stuff[GearSlot.Back] = gears;
            }

            if (gears.Slot == GearSlot.Chest)
            {
                Stuff[GearSlot.Chest] = gears;
            }

            if (gears.Slot == GearSlot.Feet)
            {
                Stuff[GearSlot.Feet] = gears;
            }

            if (gears.Slot == GearSlot.Head)
            {
                Stuff[GearSlot.Head] = gears;
            }

            if (gears.Slot == GearSlot.Legs)
            {
                Stuff[GearSlot.Legs] = gears;
            }
        }

        public int GetTotalDamage()
        {
            HandledItem arme1, arme2;
            int total = 0;
            arme1 = (HandledItem)GetItemInSlot(GearSlot.Weapon);
            arme2 = (HandledItem)GetItemInSlot(GearSlot.OffHand);
            total += arme1.Damage + arme2.Damage;

            return total;
        }

        public int GetTotalDefence()
        {
            HandledItem arme1, arme2;
            Armor armor1, armor2, armor3, armor4, armor5;
            int total = 0;
            arme1 = (HandledItem)GetItemInSlot(GearSlot.Weapon);
            arme2 = (HandledItem)GetItemInSlot(GearSlot.OffHand);


            armor1 = (Armor)GetItemInSlot(GearSlot.Head);
            armor2 = (Armor)GetItemInSlot(GearSlot.Back);
            armor3 = (Armor)GetItemInSlot(GearSlot.Chest);
            armor4 = (Armor)GetItemInSlot(GearSlot.Legs);
            armor5 = (Armor)GetItemInSlot(GearSlot.Feet);

            if (Stuff[GearSlot.Head] != null)
            {
                total += armor1.Defence;
            }
            if (Stuff[GearSlot.Back] != null)
            {
                total += armor2.Defence;
            }
            if (Stuff[GearSlot.Chest] != null)
            {
                total += armor3.Defence;
            }
            if (Stuff[GearSlot.Legs] != null)
            {
                total += armor4.Defence;
            }
            if (Stuff[GearSlot.Feet] != null)
            {
                total += armor5.Defence;
            }

            total += arme1.Defence + arme2.Defence;

            return total;
        }

        public Gear GetItemInSlot(GearSlot slot)
        {
            if (Stuff[slot] != null)
            {
                return Stuff[slot];
            }
            else
            {
                return null;
            }
        }
    }
}
