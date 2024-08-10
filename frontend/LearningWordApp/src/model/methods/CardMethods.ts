import { Application } from "../types/Application";
import { changeTranslationInCard, changeWordInCard, createCard } from "../types/Card";
import { deleteCardFromDeck } from "../types/Deck";

function addNewCard(app: Application, deckId: string, word: string, translation: string): Application {
    const updatedDecks = app.decks.map(deck => {
        if (deck.id !== deckId) {
            return deck;
        }
        return {
            ...deck,
            cards: deck.cards.concat(createCard(word, translation))
        };
    });

    return {
        ...app,
        decks: updatedDecks
    };
}

function deleteCard(app: Application, deckId: string, cardId: string): Application {
    const updatedDecks = app.decks.map(deck => {
        if (deck.id !== deckId) {
            return deck;
        }
        return deleteCardFromDeck(deck, cardId);
    });

    return {
        ...app,
        decks: updatedDecks
    };
}

function changeCardWord(app: Application, deckId: string, cardId: string, newWord: string): Application {
    const updatedDecks = app.decks.map(deck => {
        if (deck.id !== deckId) {
            return deck;
        }
        return {
            ...deck,
            cards: deck.cards.map(card => {
                if (card.id !== cardId) {
                    return card;
                }
                return changeWordInCard(card, newWord);
            })
        }
    });

    return {
        ...app,
        decks: updatedDecks
    };
}

function changeCardTranslation(app: Application, deckId: string, cardId: string, newTranslation: string): Application {
    const updatedDecks = app.decks.map(deck => {
        if (deck.id !== deckId) {
            return deck;
        }
        return {
            ...deck,
            cards: deck.cards.map(card => {
                if (card.id !== cardId) {
                    return card;
                }
                return changeTranslationInCard(card, newTranslation);
            })
        };
    });

    return {
        ...app,
        decks: updatedDecks
    };
}

export {
    addNewCard,
    deleteCard,
    changeCardWord,
    changeCardTranslation
}