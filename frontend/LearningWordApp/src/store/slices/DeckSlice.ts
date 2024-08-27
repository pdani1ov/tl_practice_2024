import { StateCreator } from "zustand";
import { Application } from "../../model/types/Application";
import { Deck } from "../../model/types/Deck";
import { addNewDeck, changeDeckName, deleteDeck, getDeckById } from "../../model/methods/DeckMethods";

export type DeckSlice = {
  addNewDeck: (name: string) => void;
  removeDeck: (deckId: string) => void;
  changeDeckName: (deckId: string, newName: string) => void;
  getDeckById: (deckId: string) => Deck;
};

export const createDeckSlice: StateCreator<DeckSlice & { info: Application }, [], [], DeckSlice> = (set, get) => ({
  addNewDeck: (name: string) => {
    set((state) => ({
      info: addNewDeck(state.info, name),
    }));
  },
  removeDeck: (deckId: string) => {
    set((state) => ({
      info: deleteDeck(state.info, deckId),
    }));
  },
  changeDeckName: (deckId: string, newName: string) => {
    set((state) => ({
      info: changeDeckName(state.info, deckId, newName),
    }));
  },
  getDeckById: (deckId: string) => {
    return getDeckById(get().info, deckId);
  },
});
