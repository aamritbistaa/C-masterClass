This is a implementation for drawing card in hand, in random order


protected private class and implemented  logic of drawing card from stash and removing it, to implement poker and blackjack drawing card 
use of enum to specify different type of card numbers and symbol or suit(spade, heart,diamond,club)
created a abstract class deck
	it has methods like creating a deck, shuffling it, and also drawingcard from the deck
	also used list to store these cards
this abstract class had a method DealCard, which can be used to draw cards based on game (number of card)
implemented different access specifier like protected, public, and private to do these operation

these abstract classes were implemented or inherited by different game class like poker, or blackjack depending on number of card required
also used method overriding to draw the card 