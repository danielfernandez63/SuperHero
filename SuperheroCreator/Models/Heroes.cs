﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperheroCreator.Models
{
    public class Heroes
    {

        //view list of all superheroes
        //CRUD  superhero 
        //add a different bootstrap theme
        //add image as home

        [Key]

        public string Name { get; set; }

        public string AlterEgo { get; set; }

        public string PrimaryAbility { get; set; }

        public string SecondaryAbility { get; set; }

        public string CatchPhrase { get; set; }

    }
}