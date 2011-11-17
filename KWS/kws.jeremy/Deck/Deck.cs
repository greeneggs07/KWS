namespace Deck
{
    public class Deck
    {
        protected int currentIndex;
        private Card.Card[] cards = new Card.Card[50];
        private Card.Card currentCard;
        private const int lastCard = 49;
        private const int firstCard = 0;

        //currently not implemented because I don't know how
        public bool loadSlides(Presentation ppt)
        {
            //do stuff
            return false;
        }

        public Card.Card getNext(Card.Card next)
        {
            if (next.index + 1 >= 50)
                return cards[firstCard];
            else
                return cards[next.index + 1];
        }

        public Card.Card getPrev(Card.Card next)
        {
            if (next.index - 1 < 0)
                return cards[lastCard];
            else
                return cards[next.index - 1];
        }

        public void clear()
        {
            for (int i = 0; i < 50; i++)
            {
                cards[i] = null;
            }
        }

        public void draw()
        {
            //do stuff
        }
    }
}
