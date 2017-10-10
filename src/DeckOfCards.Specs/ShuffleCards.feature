Feature: Shuffle cards in the deck
    In order to play a card game
    As a dealer
    I want to be able to shuffle the card deck

@ignore
Scenario: Shuffle a deck
    Given a new deck
    When I shuffle the deck
    Then the order of cards should change

#TODO: should this be in the unit tests?
@ignore
Scenario: Shuffle two decks
    Given two new decks
    When I shuffle both decks
    Then the order of cards in each deck should be different
