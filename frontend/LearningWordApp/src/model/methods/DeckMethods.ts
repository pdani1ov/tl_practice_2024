import { Application } from "../types/Application";
import { createDeck, changeName, Deck } from "../types/Deck";

function addNewDeck(app: Application, name: string): Application {
  return {
    ...app,
    decks: app.decks.concat(createDeck(name)),
  };
}

function deleteDeck(app: Application, deckId: string): Application {
  return {
    ...app,
    decks: app.decks.filter((deck) => deck.id !== deckId),
  };
}

function changeDeckName(app: Application, deckId: string, newName: string): Application {
  const updatedDecks = app.decks.map((deck) => {
    if (deck.id !== deckId) {
      return deck;
    }
    return changeName(deck, newName);
  });

  return {
    ...app,
    decks: updatedDecks,
  };
}

function getDeckById(app: Application, deckId: string): Deck {
  const [neededDeck] = app.decks.filter((deck) => deck.id === deckId);
  return neededDeck;
}

export { addNewDeck, deleteDeck, changeDeckName, getDeckById };
