using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois que la lettre n'est pas dans le mot
    public class WrongGuessEvent : GameEvent
    {
        public override string EventType { get { return "WrongGuess"; } }
    
        // TODO: Compléter
        public WrongGuessEvent(GameData gameData) {
            //si joueur na pas le bon guess, nombre wong guess increase
            gameData.NbWrongGuesses++; 

            // si on a plus de wrong guesses que le maximum (constant dans la classe gamedata) on cree un losing event
            if(gameData.NbWrongGuesses >= GameData.NB_WRONG_TRIES_FOR_LOSING)
            {
                Events = new List<GameEvent> { new LostEvent(gameData) }; 
            }

        }
    }
}
