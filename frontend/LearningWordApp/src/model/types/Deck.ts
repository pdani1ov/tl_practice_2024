import { Card } from "./Card";
import { v4 as uuidv4 } from "uuid";

export interface Deck {
  id: string;
  name: string;
  cards: Card[];
}

function createDeck(name: string): Deck {
  return {
    id: uuidv4(),
    name,
    cards: [],
  };
}

function changeName(deck: Deck, name: string): Deck {
  return {
    ...deck,
    name,
  };
}

function deleteCardFromDeck(deck: Deck, cardId: string): Deck {
  return {
    ...deck,
    cards: deck.cards.filter((card) => card.id !== cardId),
  };
}

export { createDeck, changeName, deleteCardFromDeck };
