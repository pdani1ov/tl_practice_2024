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
    const canMoveCurrentCardToUnlearnedCardsEnd = deck.unlearnedCards.length >= 2;

    if (!canMoveCurrentCardToUnlearnedCardsEnd)
    {
        return deck;
    }

    const currentCard = deck.unlearnedCards[0];
    const otherCardsWithoutFirst = deck.unlearnedCards.slice(1);
    const updatedUnlearnedCards = [ ...otherCardsWithoutFirst, currentCard ];

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