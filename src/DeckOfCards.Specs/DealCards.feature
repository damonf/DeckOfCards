Feature: Deal cards from the deck
    In order to play a card game
    As a dealer
    I want to be able to deal cards

Scenario: Deal no cards
    Given I have a new standard deck of cards with jokers
    When I deal no cards 
    Then there should be 54 cards in the deck

Scenario: Deal a card
    Given I have a new deck of cards
    When I deal a card
    Then a card should be produced

Scenario: Dealing all the cards
    Given I have a new standard deck of cards with jokers
    When I deal all the cards 
    Then there should be 54 cards
        And there should be the following cards
        | suit     | values                                                                       |
        | Clubs    | Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King |
        | Diamonds | Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King |
        | Spades   | Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King |
        | Hearts   | Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King |
        And there should be 2 jokers

Scenario: Cannot deal cards from an empty deck
    Given I have an empty deck
    When I try to deal a card
    Then I am presented with an error

