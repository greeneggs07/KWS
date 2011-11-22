using KWS;

namespace KWS_Deck
{
    public class Deck
    {
        protected int currentIndex;
        private Card[] cards;
        private int size; //size of card array, passed in during construction
        private int lastCard;
        private int firstCard = 0;

        public Deck(int size)
        {
            cards = new Card[size];
            this.size = size;
            lastCard = size - 1;
        }

        public Card getNext(Card next)
        {
            if (next.index + 1 >= size)
            {
                currentIndex = firstCard;
                return cards[firstCard];
            }
            else
            {
                currentIndex++;
                return cards[currentIndex];
            }
        }

        public Card getPrev(Card next)
        {
            if (next.index - 1 < 0)
            {
                currentIndex = lastCard;
                return cards[lastCard];
            }
            else
            {
                currentIndex--;
                return cards[currentIndex];
            }
        }

        public void clear()
        {
            for (int i = 0; i < 50; i++)
            {
                cards[i] = null;
            }
        }

        public void swap(Card card)
        {
            Card temp = cards[currentIndex];
            cards[currentIndex] = card;

        }
    }
}
