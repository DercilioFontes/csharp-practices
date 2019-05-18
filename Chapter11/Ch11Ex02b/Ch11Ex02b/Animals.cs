﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Ex02b
{
    class Animals : DictionaryBase
    {
        public void Add(string newID, Animal newAnimal)
        {
            Dictionary.Add(newID, newAnimal);
        }
        public void Remove(string animalID)
        {
            Dictionary.Remove(animalID);
        }
        public Animal this[string animalID]
        {
            get { return (Animal)Dictionary[animalID]; }
            set { Dictionary[animalID] = value; }
        }
    }
}