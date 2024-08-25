import { create } from "zustand";
import { Application } from "../model/types/Application";
import { createJSONStorage, persist } from "zustand/middleware";
import { addNewDeck, changeDeckName, deleteDeck, getDeckById } from "../model/methods/DeckMethods";
import {
  addNewCard,
  changeCardTranslation,
  changeCardWord,
  deleteCard,
  getCardById,
} from "../model/methods/CardMethods";
import { Deck } from "../model/types/Deck";
import { Card } from "../model/types/Card";

type AppStoreData = {
  info: Application;
  actions: {
    addNewDeck: (name: string) => void;
    removeDeck: (deckId: string) => void;
    changeDeckName: (deckId: string, newName: string) => void;
    addNewCard: (deckId: string, word: string, translation: string) => void;
    removeCard: (deckId: string, cardId: string) => void;
    changeCardWord: (deckId: string, cardId: string, newWord: string) => void;
    changeCardTranslation: (deckId: string, cardId: string, newTranslation: string) => void;
    getDeckById: (deckId: string) => Deck;
    getCardById: (deckId: string, cardId: string) => Card;
  };
};

export const useAppStore = create<AppStoreData>()(
  persist(
    (set, get) => ({
      info: {
        decks: [],
      },
      actions: {
        addNewDeck: (name: string) => {
          set({ ...get(), info: addNewDeck(get().info, name) });
        },
        removeDeck: (deckId: string) => {
          set({ ...get(), info: deleteDeck(get().info, deckId) });
        },
        changeDeckName: (deckId: string, newName: string) => {
          set({ ...get(), info: changeDeckName(get().info, deckId, newName) });
        },
        addNewCard: (deckId: string, word: string, translation: string) => {
          set({ ...get(), info: addNewCard(get().info, deckId, word, translation) });
        },
        removeCard: (deckId: string, cardId: string) => {
          set({ ...get(), info: deleteCard(get().info, deckId, cardId) });
        },
        changeCardWord: (deckId: string, cardId: string, newWord: string) => {
          set({ ...get(), info: changeCardWord(get().info, deckId, cardId, newWord) });
        },
        changeCardTranslation: (deckId: string, cardId: string, newTranslation: string) => {
          set({ ...get(), info: changeCardTranslation(get().info, deckId, cardId, newTranslation) });
        },
        getDeckById: (deckId: string) => getDeckById(get().info, deckId),
        getCardById: (deckId: string, cardId: string) => getCardById(get().info, deckId, cardId),
      },
    }),
    {
      name: "word-learning-app-tl",
      storage: createJSONStorage(() => localStorage),
      partialize: (state) => ({ ...state, actions: undefined }),
    },
  ),
);
