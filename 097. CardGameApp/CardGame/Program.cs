using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Poker game = new Poker();
            var hand = game.DealCard();

            foreach (var card in hand)
            {
                Console.WriteLine($"{card.Suite.ToString()} of {card.Value.ToString()}");    
            }
            Console.ReadLine();
            BlackJack blackJack = new BlackJack();
            var hand2=blackJack.DealCard();
            foreach (var card in hand2)
            {
                Console.WriteLine($"{card.Suite.ToString()} of {card.Value.ToString()}");
            }
            Console.ReadLine();
        }
    }
    public class BlackJack : Deck
    {
        public BlackJack()
        {
            CreateDeck();
            ShuffleDeck();
        }
        public override List<PlayingCard> DealCard()
        {
            List<PlayingCard> output = new List<PlayingCard>();
            for (int i = 0; i < 2; i++)
            {
                output.Add(DrawOneCard());
            }
            return output;
        }
        public PlayingCard RequestCard()
        {
            return DrawOneCard();
        }
    }
    public class Poker : Deck
    {
        public Poker()
        {
            CreateDeck();
            ShuffleDeck();
        }
        public override List<PlayingCard> DealCard()
        {
            List<PlayingCard> output = new List<PlayingCard>();  
            for(int i = 0; i < 5; i++)
            {
                output.Add(DrawOneCard());
            }
            return output;
        }
        public List<PlayingCard> RequestCards(List<PlayingCard> cardsToDiscard)
        {
            List<PlayingCard> output = new List<PlayingCard>();
            foreach (var item in cardsToDiscard)
            {
                output.Add(DrawOneCard());
                discardPile.Add(item);
            }
            return output;
        }
    }
    public abstract class Deck
    {
        protected List<PlayingCard> fulldeck = new List<PlayingCard>() ;
        protected List<PlayingCard> drawPile = new List<PlayingCard>() ;
        protected List<PlayingCard> discardPile = new List<PlayingCard>() ;
        protected void CreateDeck()
        {
            fulldeck.Clear() ;
            for(int suit = 0; suit < 4; suit++)
            {
                for(int val = 0; val < 13; val++)
                {//typecasting
                    fulldeck.Add(new PlayingCard { Suite = (CardSuit)suit, Value = (CardValue)val });
                }
            }
        }
        public virtual void ShuffleDeck()
        {
            Random random = new Random();
            //order sorts the list on the basis of value in this case, random number [random.Next()]
            drawPile=fulldeck.OrderBy(x => random.Next()).ToList();
        }
        
        public abstract List<PlayingCard> DealCard();

        protected virtual PlayingCard DrawOneCard()
        {
            PlayingCard output = drawPile.Take(1).First();
            drawPile.Remove(output);
            return output;
        }
    }
    public class PlayingCard
    {
        public CardSuit Suite {  get; set; }
        public CardValue Value { get; set; }
    }

    public enum CardValue
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
    public enum CardSuit
    {
        Diamonds,
        Spade,
        Clubs,
        Hearts
    }
}

