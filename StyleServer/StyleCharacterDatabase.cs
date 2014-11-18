using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StyleServer
{
    class StyleCharacterDatabase
    {

        public List<StyleCharacter> characterList;


        public StyleCharacterDatabase()
        {
            characterList = new List<StyleCharacter>();
        }
        

        public void AddCharacter(StyleCharacter character) //adds a character to the database
        {
            characterList.Add(character);
        }

    }
}
