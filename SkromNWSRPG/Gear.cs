﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkromNWSRPG
{
    /*
     * Cette classe représente un équippement dans notre RPG
     * Il possède un emplacement d'équipement GearSlot de nom Slot
     * C'est une classe Abstraite
     * Elle hérite de la classe Item
     */
    public abstract class Gear : Item
    {
        public GearSlot Slot;

        public Gear(string name, GearSlot slot):base(name)
        {
            Slot = slot;
        }
    }
}
