Feature: Compare cards from the deck
    In order to play a card game
    As a player
    I want to be able to compare cards

Scenario: Compare two cards
    Given I have a Two of Clubs
    And I have a Three of Clubs
    When I compare the cards
    Then the Three of Clubs should be higher
