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
    const canChange = deck.unlearnedCards.length >= 2;

    if (!canChange) {
        return deck;
    }

    const currentCard = deck.unlearnedCards[0];
    const otherCards = deck.unlearnedCards.slice(1);
    const updatedUnlearnedCards = [ ...otherCards, currentCard ];

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