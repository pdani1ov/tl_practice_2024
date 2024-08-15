import { Card } from "./Card";

export type LearningDeck = {
    id: string;
    name: string;
    unlearnedCards: Card[];
};

function getCurrentCard(deck: LearningDeck): Card | undefined {
    return deck.unlearnedCards[0];
}

function removeCurrentCard(deck: LearningDeck): LearningDeck {
    return {
        ...deck,
        unlearnedCards: deck.unlearnedCards.slice(1)
    };
}

function moveCurrentCardToDeckEnd(deck: LearningDeck): LearningDeck {
    const updatedUnlearnedCards = deck.unlearnedCards.length < 2
    ? deck.unlearnedCards
    : [ ...deck.unlearnedCards.slice(1), deck.unlearnedCards[0] ];

    return {
        ...deck,
        unlearnedCards: updatedUnlearnedCards
    };
}

export {
    getCurrentCard,
    removeCurrentCard,
    moveCurrentCardToDeckEnd
}