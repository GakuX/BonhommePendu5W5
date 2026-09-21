using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        public override string EventType { get { return "Guess"; } }

        public char Letter { get; set; }

        // TODO: Compléter
        public GuessEvent(GameData gameData, char letter) {
            // TODO: Commencez par ICI
          
            //commence par creer la liste des lettres pour sauvegarder les lettres utilise pour deviner
            var events = new List<GameEvent> { new GuessedLetterEvent(gameData, letter)};

            bool foundletter = false; 

            for(int i = 0; i < gameData.RevealedWord.Length; i++)
            {
                 if(gameData.HasSameLetterAtIndex(letter,i))
                {
                    foundletter = true; 
                    events.Add(new RevealLetterEvent(gameData, letter, i)); 
                }
            }

            if (!foundletter)
            {
                events.Add(new WrongGuessEvent(gameData)); 
            }
            Events = events; 
          
        }
    }
}
