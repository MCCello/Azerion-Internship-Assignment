# Azerion-Internship-Assignment
 Poker hand sorting algorithm assignment for Graduation Internship
 
 
 # Assumptions:
 1 - Repeated cards are allowed thus infinite number of decks for simplicity (shown in example list of hands)
 <br> 2 - The BU folder in the card assets was not necessary
 
 
 # Explanation
 1 - The game starts by initializing a deck of cards for all scripts to access thus reducing the amount of initialization needed for cards drastically
 <br> 2 - The player script consists of rankings & hands which are created on start by the hand generator that takes random cards from the aforementioned deck
 <br> 2.a - given that the assumption of repeated cards is in place & no rules about number of decks; hand generator grabs random cards from the original deck thus there is a chance that the same card is grabbed twice (albeit 1/2704 chances)
 <br> 3 - the Hand Validator is pretty simple and most of the logic for checking combinations was scraped from different online sources, the greatest achievement is using the architecture I made in order to keep consistent and clean code by storing rankings within the player classes.
 <br> 4 - each player class can check their hands simultaneously as the hand validator main method CheckHandResults() takes as parameter a list of cards and returns a ranking which is stored in the player class.
 <br> The SortAllHAnds script then makes sure every player's hand is validated and ranked, in turn it will then sort all players by rank and then by descending order of card numbers as it must check which two pairs are higher (or three of a kind, etc)
 <br> The sort all hands then loops thru all the players and whoever is sorted first in the previous line will be the winner, which is shown in the UI via a text change.
 <br> the spawn cards script is a bit out of the loop but it is called via a button to show all player cards.

# UML
![alt text](https://i.imgur.com/ve5RvDQ.jpg)

